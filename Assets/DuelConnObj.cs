using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayCli;
using PlayCli.ProtoMod;
using UnityEngine;

public class DuelConnObj : MonoBehaviour {
    // Start is called before the first frame update
    public DuelConnector conn;
    public Room current_room;
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
        Room tmp = await this.conn.CreateRoom ();
        return true;
    }

    public void JoinRoom (string key, bool is_player) {

    }

}