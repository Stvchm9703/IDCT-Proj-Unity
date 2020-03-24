using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAlertPanel : MonoBehaviour {

    public GameObject Panel;
    public scriptGameVS MainCtlvs;
    public scriptGame MainCtl;
    public scriptGameVSGUI MainCtlvsGui;
    public bool GivePanelIsOpen = false;

    void Start() {
        Debug.Log("gu panel start");
        if (Panel == null) {
            Debug.Log("missing");
            Panel = this.transform.Find("GameAlertPanel").gameObject;
        }

    }
    void Update() {
        Panel.SetActive(GivePanelIsOpen);
    }
    public void giveupcloseclick() {
        if (MainCtlvs != null)
            MainCtlvs.GameAlertClose();
        else if (MainCtlvsGui != null)
            MainCtlvsGui.GameAlertClose();

        GivePanelIsOpen = false;
    }
}