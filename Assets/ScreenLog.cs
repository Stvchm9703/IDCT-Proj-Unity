using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenLog : MonoBehaviour {
    // Start is called before the first frame update

    public string Title;
    public string Information;
    public void SetMsg (string t , string info){
        this.transform.Find("Title").gameObject.GetComponent<Text>().text = t;
        this.transform.Find("Info").gameObject.GetComponent<Text>().text = info;
        this.Title = t;
        this.Information = info;
    }
}