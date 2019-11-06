using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using PlayCli;
using PlayCli.ProtoMod;
using UnityEngine;
public class DuelConnObj : MonoBehaviour {
    // Start is called before the first frame update
    public DuelConnector conn;
    public Room current_room;
    public AsyncServerStreamingCall<CellStatus> stream_status;
    void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag ("Connector");
        if (objs.Length > 1) {
            Destroy (this.gameObject);
        } else {
            DontDestroyOnLoad (this.gameObject);
            this.conn = new DuelConnector (new CfServerSetting { });
        }
    }

    public async Task<bool> CreateRoom () {
        // open loading 
        current_room = await this.conn.CreateRoom ();
        stream_status = this.conn.GetRoomStream (current_room.Key);
        return true;
    }

    public async Task<bool> JoinRoom (string key, bool is_player) {
        current_room = await this.conn.GetRoomInfo (key);
        stream_status = this.conn.GetRoomStream (key);
        return true;
    }

    public async Task<List<Room>> GetRoomList (string para) {
        return await this.conn.GetRoomList (para);
    }

    public async Task<bool> UpdateTurn (CellStatus cs) {
        return await this.conn.UpdateRoomTurn (cs);
    }
    async void Destroy(){
        // this.conn destruct call;
        
    }
}