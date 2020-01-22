using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAlertRender : MonoBehaviour {
    public GameAlertPanel Controller;
    GUIContent btn_gui;
    public GUIStyle default_gui;
    Vector2 position_;
    Vector2 size_bx;
    void Start () {
        if (!this.Controller) {
            this.Controller = this.gameObject.GetComponent<GameAlertPanel> ();
        }
        btn_gui = new GUIContent ();
        float g = 0;
        if (Screen.width < Screen.height) {
            g = Screen.width;
        } else {
            g = Screen.height;
        }
        size_bx.x = (float) (g * 0.3);
        size_bx.y = (float) (g * 0.1);
        position_.x = (float) (Screen.width / 2 - size_bx.x / 2);
        position_.y = Screen.height;

        // Debug.Log(position_);
        default_gui.fontSize = (int) (48);
    }
    void OnGUI () {
        if (this.gameObject.activeSelf) {
            GUI.skin.button = default_gui;

            var y = new GUIContent (btn_gui);
            y.text = "Close";

            if (GUI.Button (new Rect (position_.x, (float) (position_.y * 0.8), (float) (size_bx.x), (float) (size_bx.y)), y)) {
                this.Controller.giveupcloseclick ();
            }
        }
    }
}