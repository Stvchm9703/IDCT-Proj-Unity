using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAlertPanel : MonoBehaviour {

    public GameObject Panel;
    public scriptGameVS MainCtlvs;
    public scriptGame MainCtl;
    public bool GivePanelIsOpen = false;

    void Start () {
        Debug.Log ("gu panel start");
        if (Panel == null) {
            Debug.Log ("missing");
            Panel = this.transform.Find ("GameAlertPanel").gameObject;
        }
        if (MainCtl == null) {
            MainCtl = this.GetComponent<scriptGame> ();
        }
        if (MainCtlvs == null) {
            MainCtlvs = this.GetComponent<scriptGameVS> ();
        }

    }
    void Update () {
        Panel.SetActive (GivePanelIsOpen);
    }
    public void giveupcloseclick () {
        MainCtlvs.GameAlertClose();
        GivePanelIsOpen = false;
    }
}