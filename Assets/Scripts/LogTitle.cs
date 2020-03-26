using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
// using UnityEngine.UIElements;
public class LogTitle : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        this.gameObject.GetComponent<Text>().text =
            this.transform.parent.gameObject.GetComponent<ScreenLog>().Title;

        this.gameObject.GetComponent<Text>().text =
            this.transform.parent.gameObject.GetComponent<ScreenLog>().Title;
    }
}