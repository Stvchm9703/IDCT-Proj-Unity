using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class LogInfo : MonoBehaviour {
    void Start () {
        // UnityEngine.UIElements.TextElement
        this.gameObject.GetComponent<TextElement> ().text =
            this.transform.parent.gameObject.GetComponent<ScreenLog> ().Information;
    }
}