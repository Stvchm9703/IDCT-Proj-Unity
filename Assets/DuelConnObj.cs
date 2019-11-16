using System.Collections;
using System.Collections.Generic;
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
    // public AsyncServerStreamingCall<CellStatus> stream_status;
    bool able_update = false;
    public CfServerSetting Win_DevTmp = new CfServerSetting {
        Connector = "grpc",
        Host = "127.0.0.1",
        Port = 11000,
        Database = "",
        Username = "TestUser",
        Password = "",
        Key = "Uk54398",
        KeyPemPath = "A:\\Gitrepo\\IDCT-Proj-Unity\\server.pem",
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
            this.conn = new DuelConnector (
                // Config.LoadCfFile (this.config_file).remote
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
            current_room = await this.conn.GetRoomInfo (key);
            this.able_update = is_player;
            // Get Stream 
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

    public bool ExitRoom (string para) {
        // Time.Wait
        return true;
    }

    void Destroy () {
        // this.conn destruct call;

    }
}