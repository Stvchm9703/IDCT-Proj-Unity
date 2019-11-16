using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveUpRender : MonoBehaviour {
    public GiveUpPanel Controller;
    GUIContent btn_gui;
    public GUIStyle default_gui;
    Vector2 position_;
    void Start () {
        if (!this.Controller) {
            this.Controller = GameObject.FindWithTag ("Controller").GetComponent<GiveUpPanel> ();
        }
        btn_gui = new GUIContent ();
        position_.x = Screen.width / 2 - 80;
        position_.y = this.gameObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 50;
        Debug.Log (position_);
    }
    void OnGUI () {
        if (this.gameObject.active) {
            GUI.skin.button = default_gui;
            var t = new GUIContent (btn_gui); //copy
            t.text = "Quit Game";
            if (GUI.Button (new Rect (position_.x, position_.y + 30, 160, 45), t)) {
                this.Controller.giveuponclick ();
            }

            var y = new GUIContent (btn_gui);
            y.text = "Close";
            if (GUI.Button (new Rect (position_.x, position_.y + 100, 160, 45), y)) {
                this.Controller.giveupcloseclick ();
            }
        }
    }
}