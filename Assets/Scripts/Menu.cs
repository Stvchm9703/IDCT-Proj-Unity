using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    public GameObject WarnPanel;
    public void GotoACCreate() {
        SceneManager.LoadScene("AccountCreate", LoadSceneMode.Single);
    }
    public void GotoCPU() {
        SceneManager.LoadScene("AIGame", LoadSceneMode.Single);
    }
    public void GotoRoomSearch() {
        if (!File.Exists(Path.Combine(PlayCli.ConfigPath.StreamingAsset, "config.yaml")) &&
            !File.Exists(Path.Combine(PlayCli.ConfigPath.StreamingAsset, "key.pem"))) {
            WarnPanel.SetActive(true);
        }
        SceneManager.LoadScene("RoomSearch", LoadSceneMode.Single);
    }
    public void GotoDebugTest() {
        SceneManager.LoadScene("DebugRunConsole", LoadSceneMode.Single);
    }
    private void Start() {
        if (WarnPanel == null) {
            WarnPanel = this.transform.Find("WarningPanel").gameObject;
        }
        WarnPanel.SetActive(false);
        // if (File.Exists())
        if (!File.Exists(Path.Combine(PlayCli.ConfigPath.StreamingAsset, "config.yaml")) &&
            !File.Exists(Path.Combine(PlayCli.ConfigPath.StreamingAsset, "key.pem"))) {
            WarnPanel.SetActive(true);
        }
    }
}