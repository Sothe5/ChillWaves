using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingTab : MonoBehaviour {

    public int page;
    public GameObject content;
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = (this.page == SettingsController.page) ? new Color(255, 255, 255) : new Color(197, 197, 197, 0.7f);
        if (content != null) {
            content.SetActive(page == SettingsController.page);
        }
    }

    void OnMouseDown()
    {
        SettingsController.page = this.page;
    }
}
