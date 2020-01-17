using System.Collections;
using System.Collections.Generic;
using PlayCli.ProtoModv2;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RoomContainer : MonoBehaviour, IPointerClickHandler {
    public RoomSearch rs_ctl;
    public Room targ_room;
    public Text Host;
    public Text Dueler;
    public Text RmKey;
    public Text Turn;
    public void OnPointerClick (PointerEventData eventData) {
        Debug.Log ((RectTransform) (this.transform));
        rs_ctl.GoToRoom (targ_room.Key);
    }
    public void SetVal () {
        if (targ_room != null) {
            Host.text = "<Host>:" + targ_room.HostId;
            Dueler.text = "<Dueler>:" + targ_room.DuelerId;
            RmKey.text = "<RoomKey>:" + targ_room.Key;
            Turn.text = "Turns:" + (targ_room.Round + 1).ToString ();
        }
    }
    void Start () {
        if (rs_ctl == null) {
            rs_ctl = this.transform.parent.parent.parent.parent.gameObject.GetComponent<RoomSearch> ();
        }
    }
}