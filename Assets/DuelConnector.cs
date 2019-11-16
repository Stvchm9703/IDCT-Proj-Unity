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

        private string HostId {
            get {
                return this.UserID + "-" + this.Key;
            }
        }
        private Channel channel;
        private RoomStatus.RoomStatusClient client;

        public DuelConnector (CfServerSetting s) {
            var crt = new SslCredentials (File.ReadAllText (s.KeyPemPath));
            this.channel = new Channel (
                s.Host + ":" + s.Port,
                crt);
            this.UserID = s.Username;
            this.Key = s.Key;
            this.client = new RoomStatus.RoomStatusClient (this.channel);
        }

        public async Task<Room> CreateRoom () {
            return await this.client.CreateRoomAsync (new RoomCreateRequest {
                HostId = this.HostId
            });
        }
        public async Task<List<Room>> GetRoomList (string requirement) {
            try {
                RoomListResponse tmp = await this.client.GetRoomListAsync (
                    new RoomListRequest {
                        Requirement = requirement,
                    }
                );
                List<Room> tt = new List<Room> ();
                foreach (var item in tmp.Result) {
                    tt.Add (item);
                }
                return tt;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }
        public async Task<Room> GetRoomInfo (string key_ref) {
            return await this.client.GetRoomInfoAsync (
                new RoomRequest { Key = key_ref }
            );
        }

        // public AsyncServerStreamingCall<CellStatus> GetRoomStream (string key_ref) {
        //     return this.client.GetRoomStream (
        //         new RoomRequest { Key = key_ref }
        //     );
        // }

        public async Task<CellStatus> UpdateRoomTurn (CellStatus cs) {
            return await this.client.UpdateRoomAsync (cs);
        }

        public async Task<bool> DeleteRoom (string key) {
            try {
                await this.client.DeleteRoomAsync (new RoomRequest {
                    Key = key,
                });
                return true;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }

        ~DuelConnector () {
            this.client = null;
            this.channel.ShutdownAsync ().Wait ();
            Debug.Log ("destructor DuelConnector");
        }

    }

}