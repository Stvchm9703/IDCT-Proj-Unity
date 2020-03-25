using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.UIElement;

[ExecuteInEditMode]
public class GiveUpPanel : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject Panel;
    public scriptGame MainCtl;
    public scriptGameVSGUI MainCtlvsGui;
    public bool IsOpen = false;

    void Start() {
        Debug.Log("gu panel start");
        if (Panel == null) {
            Debug.Log("missing");
            Panel = GameObject.Find("GiveupPanel");
        }
    }
    void Update() {
        Panel.SetActive(IsOpen);
    }

    public void giveuponclick() {
        Debug.Log("what did you done? Hello?");
        IsOpen = false;
        if (MainCtl != null)MainCtl.giveUp();
        else if (MainCtlvsGui != null)MainCtlvsGui.giveUp();
    }
    public void giveupcloseclick() {
        IsOpen = false;
    }

    public void alertOpen() {
        if (MainCtl != null && MainCtl.isGameOver) {
            MainCtl.backToMenu(); // OK
        } else if (MainCtlvsGui != null && MainCtlvsGui.isGameOver) {
            MainCtlvsGui.backToMenu(); // OK
        }
        this.IsOpen = true;
    }

}