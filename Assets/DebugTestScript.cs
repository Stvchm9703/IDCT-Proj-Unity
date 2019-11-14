using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugTestScript : MonoBehaviour {
    // Start is called before the first frame update

    public DuelConnObj TestObject;
    public GameObject Broad;
    public GameObject LogPrefab;
    void Start () {
        PrintLog ("Debug Screen", "Debug Screen in Start");
        PrintLog ("Debug Screen", "Start init Debug Screen");
        this.TestObject = gameObject.GetComponent<DuelConnObj> ();
        PrintLog ("Debug Screen", "End init Debug Screen");

    }

    // Update is called once per frame
    void Update () {

    }

    public void TestCreateRoom () {

    }

    public void TestGetListRoom () {

    }

    public void PrintLog (string title, string info) {
        // this.Broad ;
        var t = Instantiate (LogPrefab, this.Broad.transform);
        t.GetComponent<ScreenLog> ().SetMsg (title, info);
    }
}