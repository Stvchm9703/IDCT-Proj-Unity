using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;
using PlayCli.ProtoMod;
using UnityEngine;
namespace PlayCli {

    public class DuelConnector {
        private string UserID;
        private string Key;

        public string HostId { get { return this.UserID + "-" + this.Key; } }
        private Channel channel;
        private RoomStatus.RoomStatusClient client;

        public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> StreamHandler;

        public AsyncServerStreamingCall<CellStatusResp> GetOnlyStream;
        public DuelConnector(CfServerSetting s) {

            var crt = new SslCredentials(File.ReadAllText(s.KeyPemPath));

            this.channel = new Channel(
                s.Host, s.Port,
                crt);
            this.UserID = s.Username;
            this.Key = s.Key;
            this.client = new RoomStatus.RoomStatusClient(this.channel);

        }

        public async Task<Room> CreateRoom() {
            var t = await this.client.CreateRoomAsync(new RoomCreateReq {
                UserId = this.HostId
            });
            return t.RoomInfo;
        }
        public async Task<List<Room>> GetRoomList(string requirement) {
            try {
                RoomListResp tmp = await this.client.GetRoomListAsync(
                    new RoomListReq {
                        Requirement = requirement,
                    }
                );
                List<Room> tt = new List<Room>();
                foreach (var item in tmp.Result) {
                    tt.Add(item);
                }
                return tt;
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }
        public async Task<RoomResp> GetRoomInfo(string key_ref) {
            return await this.client.GetRoomInfoAsync(
                new RoomReq { Key = key_ref }
            );
        }

        public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> RoomStream() {
            this.StreamHandler = this.client.RoomStream();
            return this.StreamHandler;
        }
        public AsyncServerStreamingCall<CellStatusResp> GetRoomStream(CellStatusReq request) {
            if (this.GetOnlyStream == null) {
                this.GetOnlyStream = this.client.GetRoomStream(request);
            }
            return this.GetOnlyStream;
            // return this.client.GetRoomStream (request);
        }
        public async Task<CellStatus> UpdateRoomTurn(CellStatus cs) {
            CellStatusReq tmp = new CellStatusReq {
                UserId = this.HostId,
                Key = cs.Key,
                CellStatus = cs,
            };
            var kt = await this.client.UpdateRoomAsync(tmp);
            return kt.CellStatus;
        }

        public async Task<RoomResp> DeleteRoom(string room_key) {
            try {
                return await this.client.DeleteRoomAsync(new RoomReq {
                    Key = room_key,
                });
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }
        public async Task<bool> QuitRoom() {
            try {
                await this.client.QuitRoomAsync(new RoomCreateReq {
                    UserId = this.HostId,
                });
                return true;
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }

        ~DuelConnector() {
            if (this.StreamHandler != null) {
                var shutdownTkn = new CancellationTokenSource();
                // Debug.Log ("try kill");
                // Debug.Log (this.StreamHandler);
                this.StreamHandler.RequestStream.CompleteAsync();
                this.StreamHandler.ResponseStream.MoveNext(shutdownTkn.Token);
                shutdownTkn.Cancel();
                this.StreamHandler = null;
            }
            if (this.GetOnlyStream != null) {
                var shutdownTkn = new CancellationTokenSource();
                // Debug.Log ("try kill");
                // Debug.Log (this.GetOnlyStream);
                this.GetOnlyStream.ResponseStream.MoveNext(shutdownTkn.Token);
                shutdownTkn.Cancel();
                this.GetOnlyStream = null;
            }
            this.client = null;
            this.channel.ShutdownAsync().Wait();
            Debug.Log("destructor DuelConnector");
        }

    }

}