using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour {

    public int character;
    public bool unlocked;

    void Update()
    {
        GetComponent<SpriteRenderer>().color = (character == PlayerPrefsManager.GetCharacter()) ? new Color(255, 255, 255) : new Color(197, 197, 197, 0.5f);
    }

    void OnMouseDown()
    {
        if (unlocked)
        {
            PlayerPrefsManager.SetCharacter(character);
        }
    }
}
