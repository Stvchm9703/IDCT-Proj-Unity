﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;
using PlayCli.ProtoModv2;
using UnityEngine;
namespace PlayCli {

    public class DuelConnectorV2 {
        private string UserID;
        private string Key;

        public string HostId {
            get {
                return this.UserID + "-" + this.Key;
            }
        }
        private Channel channel;
        private RoomStatus.RoomStatusClient client;

        public DuelConnectorV2 (CfServerSetting s) {
            // TextAsset ta = Resources.Load<TextAsset>(s.KeyPemPath);
            var tt = File.ReadAllText (s.KeyPemPath);
            var crt = new SslCredentials (File.ReadAllText (s.KeyPemPath));
            this.channel = new Channel (
                s.Host + ":" + s.Port,
                crt);
            this.UserID = s.Username;
            this.Key = s.Key;
            this.client = new RoomStatus.RoomStatusClient (this.channel);
        }

        public async Task<Room> CreateRoom () {
            var t = await this.client.CreateRoomAsync (new RoomCreateReq {
                UserId = this.HostId
            });
            return t.RoomInfo;
        }
        public async Task<List<Room>> GetRoomList (string requirement) {
            try {
                RoomListResp tmp = await this.client.GetRoomListAsync (
                    new RoomListReq {
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
        public async Task<RoomResp> GetRoomInfo (string key_ref) {
            return await this.client.GetRoomInfoAsync (
                new RoomReq { Key = key_ref }
            );
        }

        public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> RoomStream () {
            return this.client.RoomStream ();
        }

        public async Task<CellStatus> UpdateRoomTurn (CellStatus cs) {
            CellStatusReq tmp = new CellStatusReq {
                UserId = this.UserID,
                Key = this.Key,
                CellStatus = cs,
            };
            var kt = await this.client.UpdateRoomAsync (tmp);
            return kt.CellStatus;
        }

        public async Task<RoomResp> DeleteRoom (string room_key) {
            try {
                return await this.client.DeleteRoomAsync (new RoomReq {
                    Key = room_key,
                });
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }
        public async Task<bool> QuitRoom () {
            try {
                await this.client.QuitRoomAsync (new RoomCreateReq {
                    UserId = this.HostId,
                });
                return true;
            } catch (RpcException e) {
                Debug.Log ("RPC failed " + e);
                throw;
            }
        }

        ~DuelConnectorV2 () {
            this.client = null;
            this.channel.ShutdownAsync ().Wait ();
            Debug.Log ("destructor DuelConnector");
        }

    }

}