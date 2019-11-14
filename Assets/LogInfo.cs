using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogInfo : MonoBehaviour {
    void Start () {
        this.gameObject.GetComponent<Text> ().text =
            this.transform.parent.gameObject.GetComponent<ScreenLog> ().Information;
    }
}