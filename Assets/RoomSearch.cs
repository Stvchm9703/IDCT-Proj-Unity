using System.Collections;
using System.Collections.Generic;
using Grpc.Core;
using Newtonsoft.Json;
using PlayCli.ProtoModv2;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomSearch : MonoBehaviour {
    public DuelConnObjv2 DuelConn;
    public GameObject Loading;
    public GameObject ContentGO;
    public GameObject ListItemPF;

    public List<Room> room_list;
    public async void RefreshList () {
        // show the loading
        Loading.SetActive (true);
        // wait loading the list
        try {
            var tmp_list = await DuelConn.GetRoomList ("");
            room_list = tmp_list;
            Debug.Log (room_list);
            this.rendRoomList (room_list);
        } catch (RpcException e) {
            string str = JsonUtility.ToJson (e);
            Debug.Log (str);
        }
        // generate the room-list gameobject 

        // complete the loading
        Loading.SetActive (false);
        return;
    }

    public async void CreateRoom () {
        // show the loading
        Loading.SetActive (true);

        // once complete the create-room phase 
        try {
            var t = await DuelConn.CreateRoom ();
            Loading.SetActive (false);
            this.RefreshList();
        } catch (RpcException e) {
            string str = JsonUtility.ToJson (e);
            Debug.Log ("create room" + str);
        }

    }
    public async void BackToMenu () {

        // destroy  DuelConnObj
        await DuelConn.ExitRoom ();
        Destroy (DuelConn);
        SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
    }

    public void GoToRoom (Room room) {
        Debug.Log("room :"+ room.Key);
        DuelConn.current_room = room;
        // DuelConn.StartBroadCast();
        DuelConn.StartGStream();
        SceneManager.LoadScene("VSGame", LoadSceneMode.Single);
    }

    public void rendRoomList (List<Room> roomlist) {
        int counter = 1;
        foreach (var t in roomlist) {
            GameObject ff = (GameObject) Instantiate (ListItemPF, new Vector3 (0, 0, 0), Quaternion.identity);
            ff.name = "Rm" + t.Key;
            ff.transform.SetParent (ContentGO.transform);
            ff.transform.position = new Vector3 (550, 320 * counter, 0);
            ff.GetComponent<RoomContainer> ().targ_room = t;
            ff.GetComponent<RoomContainer> ().SetVal ();
            counter++;
        }
    }
    void Start () {
        if (this.Loading == null) {
            this.Loading = this.transform.Find ("LoadingCanvas").gameObject;
            this.Loading.SetActive (false);
        }
        if (ContentGO == null) {
            ContentGO = this.transform.Find ("Scroll View/Viewport/Content").gameObject;
        }
    }
}