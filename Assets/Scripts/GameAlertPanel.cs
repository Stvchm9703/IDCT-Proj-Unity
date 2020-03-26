using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameAlertPanel : MonoBehaviour {

    public GameObject Panel;
    public scriptGameVS MainCtlvs;
    public scriptGame MainCtl;
    public scriptGameVSGUI MainCtlvsGui;
    public bool IsOpen = false;
    public Text MsgDisp;

    void Start() {
        Debug.Log("gu panel start");
        if (Panel == null) {
            Debug.Log("missing");
            Panel = this.transform.Find("GameAlertPanel").gameObject;
        }

    }
    void Update() {
        Panel.SetActive(IsOpen);
    }
    public void closeclick() {
        IsOpen = false;
    }

    public IEnumerator PopShow(string msg) {
        yield return false;
        MsgDisp.text = msg;
        this.IsOpen = true;
        yield return new WaitForSeconds(8f);
        this.IsOpen = false;
        yield return true;
    }

}