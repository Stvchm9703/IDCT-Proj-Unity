﻿using System.Collections;
using System.Collections.Generic;
using Grpc.Core;
using PlayCli.ProtoMod;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomSearch : MonoBehaviour {
    public GameObject DuelConn;

    public List<Room> room_list;
    public Scene back_scene;
    public async void RefreshList () {
        // show the loading
        DuelConn.transform.Find ("Loading").gameObject.SetActive (true);
        // wait loading the list
        try {
            room_list = await DuelConn.GetComponent<DuelConnObj> ().GetRoomList ("");

        } catch (RpcException e) {
            // show message ?

        }
        // generate the room-list gameobject 

        // complete the loading
        DuelConn.transform.Find ("Loading").gameObject.SetActive (false);
        return;
    }

    public async void CreateRoom () {
        // show the loading
        DuelConn.transform.Find ("Loading").gameObject.SetActive (true);

        // once complete the create-room phase 
        try {
            await DuelConn.GetComponent<DuelConnObj> ().CreateRoom ();
            // off the loading 
            DuelConn.transform.Find ("Loading").gameObject.SetActive (false);
            // start change scene
            // Scene.Load("");

        } catch (RpcException e) {
            // show fail create message 
        }

    }
    public async void BackToMenu () {
        // destroy  DuenConnObj
        Destroy (DuelConn);
        SceneManager.LoadScene ("OtherSceneName", LoadSceneMode.Single);
    }
}