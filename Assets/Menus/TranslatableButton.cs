using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslatableButton : MonoBehaviour {
    public Sprite spanish;
    public Sprite english;

    private Image myImage;
    // Use this for initialization
    void Start()
    {
        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        myImage.sprite = (PlayerPrefsManager.GetLanguage() == 0) ? spanish : english;
    }

}
