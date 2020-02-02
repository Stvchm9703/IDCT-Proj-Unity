using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogTitle : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        this.gameObject.GetComponent<Text> ().text =
            this.transform.parent.gameObject.GetComponent<ScreenLog> ().Title;
    }
}