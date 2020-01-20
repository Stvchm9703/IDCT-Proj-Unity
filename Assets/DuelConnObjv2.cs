using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;
using PlayCli;
using PlayCli.ProtoModv2;
using UnityEngine;
// using UnityEditor;

public class DuelConnObjv2 : MonoBehaviour {
    // Start is called before the first frame update
    public DuelConnectorV2 conn;
    public Room current_room;
    public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> stream_status;
    public AsyncServerStreamingCall<CellStatusResp> get_only_status_stream;
    public bool isBroadcast { get { return is_bc; } }
    bool is_bc = false;
    public bool able_update = false;
    public bool IsHost = false;
    public CfServerSetting Win_DevTmp = new CfServerSetting {
        Connector = "grpc",
        Host = "192.168.0.112",
        Port = 11000,
        Database = "",
        Username = "TestUser",
        Password = "",
        Key = "Uk54398",
        KeyPemPath = Path.Combine (Application.streamingAssetsPath, "key.pem"),
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
    public DebugTestScript DebugScn;
    public string config_file;
    void Awake () {
        Debug.Log ("on Awake process - DuelConnObj");
        GameObject[] objs = GameObject.FindGameObjectsWithTag ("Connector");
        if (objs.Length > 1) {
            Destroy (this.gameObject);
        } else {
            DontDestroyOnLoad (this.gameObject);
            this.gameObject.tag = "Connector";
            this.conn = new DuelConnectorV2 (
                Win_DevTmp
            );
        }
    }

    public async Task<bool> CreateRoom () {
        Debug.Log ("on CreateRoom process - DuelConnObj");
        // open loading 
        try {
            this.current_room = await this.conn.CreateRoom ();
            this.able_update = true;
            this.IsHost = true;
            return true;
        } catch (RpcException e) {
            Debug.Log (e);
            return false;
            throw;
        }
        // stream_status = this.conn.GetRoomStream (current_room.Key);
    }

    public async Task<bool> JoinRoom (string key, bool is_player) {
        Debug.Log ("on JoinRoom process - DuelConnObj");
        try {
            var ri = await this.conn.GetRoomInfo (key);
            current_room = ri.RoomInfo;
            this.able_update = is_player;
            this.IsHost = false;
            return true;
        } catch (RpcException e) {
            Debug.Log (e);
            return false;
            throw;
        }
    }

    public async Task<List<Room>> GetRoomList (string para) {
        return await this.conn.GetRoomList (para);
    }

    public async Task<bool> UpdateTurn (CellStatus cs) {
        try {
            CellStatus d = await this.conn.UpdateRoomTurn (cs);
            this.current_room.CellStatus.Add (d);
            return true;
        } catch (RpcException e) {
            Debug.Log (e);
            return false;
            throw;
        }
    }

    public async Task<bool> ExitRoom () {
        bool status = false;
        // Time.Wait
        if (this.current_room != null) {
            if (this.current_room.HostId == this.conn.HostId) {
                var status_r = await this.conn.DeleteRoom (this.current_room.Key);
                status = true;
                // } else if (this.current_room.HostId == this.conn.HostId && this.current_room.DuelerId != "") {
                //     status = await this.conn.QuitRoom ();

            } else if (this.current_room.DuelerId == this.conn.HostId) {
                status = await this.conn.QuitRoom ();
            } else {
                // watcher quit
                status = true;
            }
            if (status) {
                this.current_room = null;
            }
        } else {

        }
        return status;
    }

    public bool StartBroadCast () {
        if (current_room != null && stream_status == null) {
            is_bc = true;
            stream_status = this.conn.RoomStream ();

            return true;
        }
        return false;
    }

    public AsyncServerStreamingCall<CellStatusResp> StartGStream () {
        if (get_only_status_stream != null) {
            return this.get_only_status_stream;
        }
        if (current_room != null && get_only_status_stream == null) {
            get_only_status_stream = this.conn.GetRoomStream (
                new CellStatusReq {
                    Key = this.current_room.Key,
                        UserId = this.conn.HostId,
                }
            );
            return this.get_only_status_stream;
        }

        return null;
    }
    async void Destroy () {
        // this.conn destruct call;
        if (stream_status != null) {
            Debug.Log (stream_status);
            // await stream_status.RequestStream.CompleteAsync();
            // stream_status = null;
        }
    }
}