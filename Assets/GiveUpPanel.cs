﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class GiveUpPanel : MonoBehaviour {
    // Start is called before the first frame update
    public scriptGame f;

    public GameObject Panel;
    public bool GivePanelIsOpen = false;
   
    void Start () {
        Debug.Log ("gu panel start");
        if (Panel == null) {
            Debug.Log ("missing");
            Panel = GameObject.Find ("GiveupPanel");
        }
     
    }
    void Update () {
        Panel.SetActive (GivePanelIsOpen);
    }
    
    public void giveuponclick () {
        Debug.Log ("what did you done? Hello?");
        GivePanelIsOpen = false;
    }
    public void giveupcloseclick () {
        Debug.Log ("what did you done? Clsoe Hello?");
        GivePanelIsOpen = false;
    }

    public void alertOpen () {
        if (!f.isGameOver) {
            Debug.Log ("alert open click : " + f.isGameOver);
            this.GivePanelIsOpen = true;
        } else {
            f.backToMenu (); // OK
        }
    }

}