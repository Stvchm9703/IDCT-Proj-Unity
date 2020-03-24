using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.UIElement;

[ExecuteInEditMode]
public class GiveUpPanel : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject Panel;
    public scriptGameVS MainCtlvs;
    public scriptGame MainCtl;

    public scriptGameVSGUI MainCtlvsGui;
    public bool GivePanelIsOpen = false;

    void Start() {
        Debug.Log("gu panel start");
        if (Panel == null) {
            Debug.Log("missing");
            Panel = GameObject.Find("GiveupPanel");
        }
    }
    void Update() {
        Panel.SetActive(GivePanelIsOpen);
    }

    public void giveuponclick() {
        Debug.Log("what did you done? Hello?");
        GivePanelIsOpen = false;
        if (MainCtl != null)MainCtl.giveUp();
        else if (MainCtlvs != null)MainCtlvs.giveUp();
        else if(MainCtlvsGui != null) MainCtlvsGui.giveUp();
    }
    public void giveupcloseclick() {
        GivePanelIsOpen = false;
    }

    public void alertOpen() {
        if (MainCtl != null) {
            if (!MainCtl.isGameOver) {
                this.GivePanelIsOpen = true;
            } else {
                MainCtl.backToMenu(); // OK
            }
        } else if (MainCtlvs != null) {
            if (!MainCtlvs.isGameOver) {
                this.GivePanelIsOpen = true;
            } else {
                MainCtlvs.backToMenu(); // OK
            }
        }
    }

}