using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoAdjust : MonoBehaviour {

    public int ScreenWidth;
    public int ScreenHeight;

    void Awake () {
        ScreenHeight = Screen.height - 4;
        ScreenWidth = Screen.width - 4;
        float DefaultRatio = GetComponent<RectTransform> ().rect.width / GetComponent<RectTransform> ().rect.height;
        float ScreenRatio = ScreenWidth / ScreenHeight;

        if (DefaultRatio < ScreenRatio) {
            GetComponent<RectTransform> ().sizeDelta = new Vector2 (
                ScreenHeight * DefaultRatio, ScreenHeight
            );
        } else if (DefaultRatio > ScreenRatio) {
            GetComponent<RectTransform> ().sizeDelta = new Vector2 (
                ScreenWidth, ScreenWidth * DefaultRatio
            );
        } else {
            GetComponent<RectTransform> ().sizeDelta = new Vector2 (
                ScreenWidth, ScreenHeight
            );
        }
    }

}