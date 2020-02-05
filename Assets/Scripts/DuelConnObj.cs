using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using PlayCli;
using PlayCli.ProtoMod;
using UnityEngine;
// using UnityEditor;

public class DuelConnObj : MonoBehaviour {
    // Start is called before the first frame update
    public DuelConnector conn;
    public Room current_room;
    public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> stream_status;
    public AsyncServerStreamingCall<CellStatusResp> get_only_status_stream;
    public bool isBroadcast { get { return is_bc; } }
    bool is_bc = false;
    public bool able_update = false;
    public bool IsHost = false;
    // Temp setting
    public CfServerSetting Win_DevTmp = new CfServerSetting {
        Connector = "grpc",
        Host = "192.168.0.102",
        Port = 11000,
        Database = "",
        Username = "user1",
        Password = "1234",
        Key = "Uk54398", // Key should be random gen by server
        KeyPemPath = Path.Combine(Application.streamingAssetsPath, "key.pem"),
    };
    public CfServerSetting Mac_DevTmp = new CfServerSetting {
        Connector = "grpc",
        Host = "192.168.0.123",
        Port = 11000,
        Database = "",
        Username = "",
        Password = "",
        Key = "",
        KeyPemPath = "",
    };
    // Debug Scn
    public DebugTestScript DebugScn;
    public string config_file;
    void Awake() {
        Debug.Log("on Awake process - DuelConnObj");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Connector");
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
            this.gameObject.tag = "Connector";
            if (this.conn == null) {
                this.conn = new DuelConnector(Win_DevTmp);
            }
        }
    }

    public async Task<bool> CreateRoom() {
        Debug.Log("on CreateRoom process - DuelConnObj");
        // open loading 
        try {
            this.current_room = await this.conn.CreateRoom();
            this.able_update = true;
            this.IsHost = true;
            return true;
        } catch (RpcException e) {
            Debug.Log(e);
            return false;
            throw;
        }
        // stream_status = this.conn.GetRoomStream (current_room.Key);
    }

    public async Task<bool> JoinRoom(string key, bool is_player) {
        Debug.Log("on JoinRoom process - DuelConnObj");
        try {
            var ri = await this.conn.GetRoomInfo(key);
            Debug.Log(ri);
            current_room = ri.RoomInfo;
            this.able_update = is_player;
            this.IsHost = false;
            return true;
        } catch (RpcException e) {
            Debug.Log(e);
            return false;
            throw;
        }
    }

    public async Task<List<Room>> GetRoomList(string para) {
        return await this.conn.GetRoomList(para);
    }

    public async Task<bool> UpdateTurn(CellStatus cs) {
        try {
            if (able_update) {
                CellStatus d = await this.conn.UpdateRoomTurn(cs);
                this.current_room.CellStatus.Add(d);
                return true;
            }
            return false;
        } catch (RpcException e) {
            Debug.Log(e);
            return false;
            throw;
        }
    }

    public async Task<bool> ExitRoom() {
        bool status = false;
        // Time.Wait
        if (stream_status != null) {
            var shutdownTkn = new CancellationTokenSource();
            await stream_status.ResponseStream.MoveNext(shutdownTkn.Token);
            shutdownTkn.Cancel();
            stream_status = null;
        }
        if (get_only_status_stream != null) {
            var shutdownTkn = new CancellationTokenSource();
            await get_only_status_stream.ResponseStream.MoveNext(shutdownTkn.Token);
            shutdownTkn.Cancel();
            get_only_status_stream = null;
        }

        if (this.current_room != null) {
            status = await this.conn.QuitRoom();
            status = true;
            this.current_room = null;
        }

        return status;
    }

    public async Task<Room> RefreshRoomInfo() {
        if (this.current_room != null) {
            var tt = await this.conn.GetRoomInfo(current_room.Key);
            if (tt.Error == null) {
                this.current_room = tt.RoomInfo;
                return this.current_room;
            }
            // else case:
            return null;
        }
        return null;
    }

    public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> StartBroadCast() {
        if (stream_status != null)return this.stream_status;
        if (current_room != null && stream_status == null) {
            is_bc = true;
            this.stream_status = this.conn.RoomStream();
            return this.stream_status;
        }
        return null;
    }

    public AsyncServerStreamingCall<CellStatusResp> StartGStream() {
        if (get_only_status_stream != null) {
            return this.get_only_status_stream;
        }
        if (current_room != null && get_only_status_stream == null) {
            get_only_status_stream = this.conn.GetRoomStream(
                new CellStatusReq {
                    Key = this.current_room.Key,
                        UserId = this.conn.HostId,
                }
            );
            return this.get_only_status_stream;
        }

        return null;
    }
    async void Destroy() {
        // this.conn destruct call;
        if (stream_status != null) {
            Debug.Log(stream_status);
        }
    }
}