using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageButton : MonoBehaviour {

    public int language;

    void Update() {
        GetComponent<SpriteRenderer>().color = (language == PlayerPrefsManager.GetLanguage()) ? new Color(255, 255, 255):new Color(197,197,197,0.5f);
    }

    void OnMouseDown() {
        PlayerPrefsManager.SetLanguage(language);
    }
}
