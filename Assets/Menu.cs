using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    public void GotoCPU () {
        SceneManager.LoadScene ("AIGame", LoadSceneMode.Single);
    }
    public void GotoRoomSearch () {
        SceneManager.LoadScene ("RoomSearch", LoadSceneMode.Single);
    }
    public void GotoDebugTest(){
        SceneManager.LoadScene("DebugRunConsole", LoadSceneMode.Single);
    }
}