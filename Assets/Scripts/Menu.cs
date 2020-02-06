using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    public void GotoCPU() {
        SceneManager.LoadScene("AIGame", LoadSceneMode.Single);
    }
    public void GotoRoomSearch() {
        if (!File.Exists(Path.Combine(
                Application.streamingAssetsPath,
                "config.yaml"))) {

        }
        SceneManager.LoadScene("RoomSearch", LoadSceneMode.Single);
    }
    public void GotoDebugTest() {
        SceneManager.LoadScene("DebugRunConsole", LoadSceneMode.Single);
    }
    private void Start() {
        // if (File.Exists())
        if (!File.Exists(Path.Combine(
                Application.streamingAssetsPath,
                "config.yaml"))) {

        }
    }
}