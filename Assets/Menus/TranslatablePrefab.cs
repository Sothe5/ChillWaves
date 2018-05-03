using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatablePrefab : MonoBehaviour {

    public Sprite spanish;
    public Sprite english;

    private SpriteRenderer mySpriteRenderer;
    // Use this for initialization
    void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        mySpriteRenderer.sprite = (PlayerPrefsManager.GetLanguage() == 0) ? spanish : english;
	}
}
