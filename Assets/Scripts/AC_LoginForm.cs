using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AC_LoginForm : MonoBehaviour {
    public InputField address_f, username_f, pw_key_f;
    public Animator switcher;
    public GameObject LoadingPanel;
    public Text lp_text;
    public Text debug;
    public AC_CertConn conn;
    public int mainPort = 11000, authPort = 12000;
    // public string APath {
    //     get
    // }
    void Start() {
        debug.text = PlayCli.ConfigPath.StreamingAsset;
        if (address_f == null)
            address_f = this.transform.parent.Find("Canvas/login_part/server_ip").GetComponent<InputField>();
        if (username_f == null)
            username_f = this.transform.parent.Find("Canvas/login_part/username").GetComponent<InputField>();
        if (pw_key_f == null)
            pw_key_f = this.transform.parent.Find("Canvas/login_part/password").GetComponent<InputField>();

        if (switcher == null) {
            switcher = this.transform.parent.Find("Canvas").GetComponent<Animator>();
        }
        if (LoadingPanel == null) {
            LoadingPanel = this.transform.parent.Find("Canvas/LoadingPanel").gameObject;
        }
        if (lp_text == null) {
            lp_text = LoadingPanel.transform.GetComponent<Text>();
        }
    }
    public void AddressChecking(string input) {

        Regex ip = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
        MatchCollection result = ip.Matches(input);
        if (ip.IsMatch(input)) {
            Debug.Log(result[0]);

        } else {
            address_f.text = "";
            var text_box = address_f.textComponent.transform.parent.Find("Placeholder").GetComponent<Text>();
            text_box.text = "Invaild address";
            text_box.color = new Color(0.8f, 0f, 0f, 0.5f);

        }
    }
    public async void LoginAccount() {
        LoadingPanel.SetActive(true);

        var try_conn = conn.TryConnectAuthServ(address_f.text, authPort);
        lp_text.text = "Loading,\nWait for connecting authorize";

        if (!try_conn) {
            Debug.LogError("CONNECT FAIL");
            lp_text.text = "Connect Fail, Please ask for technical help";
            LoadingPanel.SetActive(false);
            return;
        }
        Debug.Log(username_f.text + ":" + pw_key_f.text);

        lp_text.text = "Loading,\nWait for login checking";
        var try_login = await conn.TryLogin(username_f.text, pw_key_f.text);
        if (!try_login) {
            Debug.LogError("Try login fail");
            lp_text.text = "Login Fail, Please ask for technical help";
            return;
        }

        lp_text.text = "Loading,\nWait for getting pem";
        var try_save_pem = await conn.GetPemFile();
        if (!try_login) {
            lp_text.text = "Login Fail, Please ask for technical help";
            return;
        }

        // Save setting
        lp_text.text = "Loading,\nWait for saving setting";
        var saving = await conn.SaveAsset();
        if (!saving) {
            Debug.LogError("Save Asset fail");
            lp_text.text = "Saving Asset Fail, Please ask for technical help";
            return;
        }

        lp_text.text = "Loading,\nWait for service testing";
        var test_run = await conn.TryConnectMain(address_f.text, mainPort);
        if (!test_run) {
            Debug.LogError("Try login fail");
            lp_text.text =
                "Connect to Main service Fail, Please ask for technical help";
            return;
        }
        Debug.Log("Complete");
        lp_text.text = "Complete";
        LoadingPanel.SetActive(false);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void SwitchToCreate() {
        switcher.Play("switch_create");
    }

}