using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using PlayCli.ProtoMod;
using UnityEngine;
using UnityEngine.UI;
public class DebugTestScript : MonoBehaviour {
    // Start is called before the first frame update

    public DuelConnObj TestObject;
    public GameObject Broad;
    public GameObject LogPrefab;
    void Start() {
        PrintLog("Debug Screen", "Debug Screen in Start");
        PrintLog("Debug Screen", "Start init Debug Screen");
        this.TestObject = gameObject.GetComponent<DuelConnObj>();
        PrintLog("Debug Screen", "End init Debug Screen");
    }

    // Update is called once per frame
    void Update() {

    }

    public async void TestCreateRoom() {
        var t = await this.TestObject.CreateRoom();
        if (t) {
            var ty = JsonConvert.SerializeObject(this.TestObject.current_room);
            PrintLog("create room ", ty);
        } else {
            PrintLog("create room", "fail");
        }
    }

    public async void TestGetListRoom() {
        List<Room> t = await this.TestObject.GetRoomList("");
        if (t.Count > 0) {
            string output = JsonConvert.SerializeObject(t);
            Debug.Log(output);
            PrintLog("list room ", output);
        } else {
            PrintLog("list room", "fail");
        }
    }

    public async void TestJoinRoom() {
        List<Room> t = await this.TestObject.GetRoomList("");
        if (t.Count > 0) {
            bool tmp = await this.TestObject.JoinRoom(t[0].Key, false);
        }
    }

    public async void TestConnSocket() {
        await this.TestObject.ConnectToBroadcast();
    }
    public async void TestCreateRoomTwo() {
        var t = await this.TestObject.CreateRoom();
        if (t) {
            var ty = JsonConvert.SerializeObject(this.TestObject.current_room);
            PrintLog("create room ", ty);
        } else {
            PrintLog("create room", "fail");
        }
        Debug.Log(this.TestObject.current_room);
        // await this.TestObject.ConnectToBroadcast();
        this.TestObject.AddEventFunc("chat_msg_recv", async(rec) => {
            Debug.Log(rec.RawText);
        });
        this.TestObject.AddEventFunc("chat_msg", async(rec) => {
            Debug.Log(rec.RawText);
        });

    }

    public async void TestSocketSend() {
        var rt = this.TestObject.conn.RoomBroadcast;
        if (rt != null) {
            await rt.EmitAsync("chat_msg", "Hello");
        } else {
            Debug.LogWarning("not connect yet");
        }
    }
    public void PrintLog(string title, string info) {
        // this.Broad ;
        var t = Instantiate(LogPrefab, this.Broad.transform);
        t.GetComponent<ScreenLog>().SetMsg(title, info);
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy() {
        this.TestObject.DisconnectToBroadcast();
    }
}