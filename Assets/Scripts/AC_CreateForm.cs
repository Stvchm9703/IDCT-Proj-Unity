using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AC_CreateForm : MonoBehaviour {
    public InputField address_f, username_f, pw_key_f;
    public Animator switcher;
    public GameObject LoadingPanel;
    public AC_CertConn conn;
    void Start() {
        if (address_f == null)
            address_f = this.transform.parent.Find("Canvas/create_part/server_ip").GetComponent<InputField>();
        if (username_f == null)
            username_f = this.transform.parent.Find("Canvas/create_part/username").GetComponent<InputField>();
        if (pw_key_f == null)
            pw_key_f = this.transform.parent.Find("Canvas/create_part/password").GetComponent<InputField>();
        if (switcher == null) {
            switcher = this.transform.parent.Find("Canvas").GetComponent<Animator>();
        }
        if (LoadingPanel == null) {
            LoadingPanel = this.transform.parent.Find("Canvas/LoadingPanel").gameObject;
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

    public async void CreateAccount() {
        LoadingPanel.SetActive(true);
        var try_conn = conn.TryConnectAuthServ(address_f.text, 12000);
        if (!try_conn) {
            Debug.LogError("CONNECT FAIL");
            return;
        }
        Debug.Log(username_f.text + ":" + pw_key_f.text);

        var try_create = await conn.CreateAccount(username_f.text, pw_key_f.text);
        if (!try_create) {
            Debug.LogError("Create fail");
            return;
        }
        // Save setting
        await conn.SaveAsset();
        LoadingPanel.SetActive(false);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void SwitchToLogin() {
        switcher.Play("switch_login");
    }
}