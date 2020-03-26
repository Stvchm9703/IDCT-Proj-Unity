using System.Collections;
using System.Collections.Generic;
using PlayCli.ProtoMod;
using UnityEngine;
// using UnityEngine.UI;
public class GUIBtnRender : MonoBehaviour {
    public int scn_margin_x;
    public int scn_margin_y;
    int scn_height = Screen.height;
    int scn_width = Screen.width;

    public GameObject ContentGO;
    public GameObject ListItemPF;
    public GUIStyle style;

    public RoomSearch rs_controller;
    void guiRefreshBtn () {
        Rect RefreshRect = new Rect (
            (scn_width / 3) * 2 - scn_margin_x, scn_margin_y,
            (scn_width / 3), (scn_height / 10)
        );
        if (GUI.Button (RefreshRect, "Refresh", style)) {
            rs_controller.RefreshList ();
        }
    }

    void guiBackToMenuBtn () {
        Rect BackToMenuRect = new Rect (
            scn_margin_x, scn_margin_y,
            (scn_width / 3), (scn_height / 10)
        );
        if (GUI.Button (BackToMenuRect, "Back To Menu", style)) {
            rs_controller.BackToMenu ();
        }

    }

    void guiCreateRoomBtn () {
        Rect CreateRoomRect = new Rect (
            (scn_width / 8), (scn_height / 10 * 9) - scn_margin_y,
            (scn_width / 4 * 3), (scn_height / 10)
        );

        if (GUI.Button (CreateRoomRect, "Create Room", style)) {
            rs_controller.CreateRoom ();
        }
    }
    public void rendRoomList (List<Room> roomlist) {
        int counter = 1;
        foreach (var t in roomlist) {
            GameObject ff = (GameObject) Instantiate (ListItemPF, new Vector3 (0, 0, 0), Quaternion.identity);
            ff.name = "Rm" + t.Key;
            ff.transform.SetParent (ContentGO.transform);
            ff.transform.position = new Vector3 (550,  320 * counter, 0);
            ff.GetComponent<RoomContainer> ().targ_room = t;
            ff.GetComponent<RoomContainer> ().SetVal ();
            counter++;
        }
    }

    void OnGUI () {
        guiBackToMenuBtn ();
        guiCreateRoomBtn ();
        guiRefreshBtn ();
    }

    void Start () {
        if (ContentGO == null) {
            ContentGO = this.transform.Find ("Scroll View/Viewport/Content").gameObject;
        }
    }

}