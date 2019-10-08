using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using PlayCli.ProtoMod;
using UnityEngine;
namespace PlayCli {
    public class DuelConnector {
        private Channel channel;
        private RoomStatus.RoomStatusClient client;

        public DuelConnector (CfServerSetting s) {
            this.channel = new Channel (
                s.Host + ":" + s.Port,
                ChannelCredentials.Insecure);
            this.client = new RoomStatus.RoomStatusClient (this.channel);
        }

        public async Task<Room> CreateRoom () {
            try {
                Room tmp = await this.client.CreateRoomAsync (new Empty { });
                Thread.Sleep (5000);
                return tmp;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }
        public async Task<List<Room>> GetRoomList (string requirement) {
            try {
                RoomListResponse tmp = await this.client.GetRoomListAsync (
                    new RoomListRequest {
                        Requirement = requirement,
                    }
                );
                List<Room> tt = new List<Room>();
                tt.AddRange (tmp.Result);
                return tt;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }
        public async Task<Room> GetRoomInfo (string key_ref) {
            try {
                Room tmp = await this.client.GetRoomCurrentInfoAsync (
                    new RoomRequest { Key = key_ref }
                );
                return tmp;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }

        public AsyncServerStreamingCall<CellStatus> GetRoomStream (string key_ref) {
            return this.client.GetRoomStream (
                new RoomRequest { Key = key_ref }
            );
        }

        public async Task<bool> UpdateRoomTurn (CellStatus cs) {
            try {
                await this.client.UpdateRoomStatusAsync (cs);
                return true;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
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