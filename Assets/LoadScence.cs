using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScence : MonoBehaviour {
    public void LoadScene (string scene_name) {
        SceneManager.LoadScene (scene_name);
    }
}