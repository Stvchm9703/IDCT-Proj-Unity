using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Debug.Log (DuelConn);
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
            Debug.Log (DuelConn.current_room.Key);
            Loading.SetActive (false);
            SceneManager.LoadScene ("VSGame", LoadSceneMode.Single);
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

    public async void GoToRoom (Room room) {
        Debug.Log ("room :" + room.Key);
        if (room.DuelerId != "") {
            await DuelConn.JoinRoom (room.Key, false);
        } else {
            await DuelConn.JoinRoom (room.Key, true);
            Debug.Log ("JoinRoom RS");
            Debug.Log (DuelConn.current_room.Key);
            var u = await DuelConn.UpdateTurn (new CellStatus {
                Key = room.Key,
                    Turn = 0,
                    CellNum = -1,
            });
            Debug.Log ("UpdataTurn ");
        }
        SceneManager.LoadScene ("VSGame", LoadSceneMode.Single);
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