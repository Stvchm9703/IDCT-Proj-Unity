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
    public CfServerSetting Win_DevTmp = new CfServerSetting {
        Connector = "grpc",
        Host = "127.0.0.1",
        Port = 11000,
        Database = "",
        Username = "",
        Password = "",
        Key = "",
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
        this.DebugScn = this.gameObject.GetComponent<DebugTestScript> ();
        Debug.Log ("on Awake process - DuelConnObj");
        DebugScn.PrintLog (" DuelConnObj", "on Awake process -");
        GameObject[] objs = GameObject.FindGameObjectsWithTag ("Connector");
        if (objs.Length > 1) {
            DebugScn.PrintLog (" DuelConnObj", "is exist more than one");
            Destroy (this.gameObject);
        } else {
            DontDestroyOnLoad (this.gameObject);
            DebugScn.PrintLog (" DuelConnObj", "create one");
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
            current_room = await this.conn.CreateRoom ();
            string str = JsonUtility.ToJson (current_room);
            Debug.Log (current_room);
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

        current_room = await this.conn.GetRoomInfo (key);
        // stream_status = this.conn.GetRoomStream (key);
        return true;
    }

    public async Task<List<Room>> GetRoomList (string para) {
        return await this.conn.GetRoomList (para);
    }

    public async Task<bool> UpdateTurn (CellStatus cs) {
        return await this.conn.UpdateRoomTurn (cs);
    }

    public bool ExitRoom (string para) {
        // Time.Wait
        return true;
    }

    void Destroy () {
        // this.conn destruct call;

    }
}