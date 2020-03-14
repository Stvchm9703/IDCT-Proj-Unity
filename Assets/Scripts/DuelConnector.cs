using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
        private Metadata header_meta;
        public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> StreamHandler;
        public AsyncServerStreamingCall<CellStatusResp> GetOnlyStream;

        private string bearer_key;
        public DuelConnector(CfServerSetting s) {
            var path = Regex.Replace(s.KeyPemPath, "%", "");
            path = path.Replace("StreamAsset/", "");
            var crt = new SslCredentials(File.ReadAllText(Path.Combine(
                PlayCli.ConfigPath.StreamingAsset, path)));

            this.channel = new Channel(
                s.Host, s.Port,
                crt);

            this.UserID = s.Username;
            this.Key = s.Key;
            this.client = new RoomStatus.RoomStatusClient(this.channel);

            // header_meta = this.refresh_meta(null, s.Username, s.Password);
        }

        private Metadata refresh_meta(Metadata resp, string username = "", string password = "") {
            var t = new Metadata();
            string bearer = "";
            if (resp != null) {
                foreach (var dff in resp) {
                    if (dff.Key == "authorization") {
                        bearer = dff.Value;
                    }
                    Debug.Log(dff.Value);
                }
            }
            if (bearer != "") {
                t.Add("authorization", bearer);
            } else {
                t.Add("username", username);
                t.Add("password", password);
            }
            return t;
        }
        public async Task<Room> CreateRoom() {
            try {
                var t = this.client.CreateRoomAsync(
                    new RoomCreateReq {
                        UserId = this.HostId
                        // },
                        // header_meta);
                    });
                header_meta = refresh_meta(await t.ResponseHeadersAsync);
                var tt = await t.ResponseAsync;
                return tt.RoomInfo;
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }
        public async Task<List<Room>> GetRoomList(string requirement) {
            try {
                var tmpp = this.client.GetRoomListAsync(
                    new RoomListReq {
                        Requirement = requirement,
                            // },
                            // header_meta);
                    });
                RoomListResp tmp = await tmpp.ResponseAsync;
                header_meta = refresh_meta(await tmpp.ResponseHeadersAsync);

                // var dfff = headMD.GetEnumerator();

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
            try {
                var reply = this.client.GetRoomInfoAsync(
                    new RoomReq { Key = key_ref }
                    // header_meta
                );
                header_meta = refresh_meta(await reply.ResponseHeadersAsync);

                return await reply.ResponseAsync;
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }

        public async Task<CellStatus> UpdateRoomTurn(CellStatus cs) {
            try {
                CellStatusReq tmp = new CellStatusReq {
                    UserId = this.HostId,
                    Key = cs.Key,
                    CellStatus = cs,
                };
                // var kt = this.client.UpdateRoomAsync(tmp, header_meta);
                var kt = this.client.UpdateRoomAsync(tmp);
                header_meta = refresh_meta(await kt.ResponseHeadersAsync);
                var cellst = await kt.ResponseAsync;
                return cellst.CellStatus;
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }

        public async Task<RoomResp> DeleteRoom(string room_key) {
            try {
                var tre = this.client.DeleteRoomAsync(new RoomReq {
                    Key = room_key,
                        // }, header_meta);
                });
                header_meta = refresh_meta(await tre.ResponseHeadersAsync);
                return await tre.ResponseAsync;
            } catch (RpcException e) {
                Debug.Log("RPC failed " + e);
                throw;
            }
        }
        public async Task<bool> QuitRoom() {
            try {
                var tre = this.client.QuitRoomAsync(new RoomCreateReq {
                    UserId = this.HostId,
                        // }, header_meta);
                });
                header_meta = refresh_meta(await tre.ResponseHeadersAsync);
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