using System.IO;
using PlayCli;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour {
    public GameObject WarnPanel;
    public Text LogPrint;
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

        var text = File.ReadAllText(Path.Combine(PlayCli.ConfigPath.StreamingAsset, "config.yaml"));

        LogPrint.text = text;
    }
}