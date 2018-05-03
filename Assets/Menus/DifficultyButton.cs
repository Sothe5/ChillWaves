using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButton : MonoBehaviour {

    public int difficulty;

    void Update()
    {
        GetComponent<SpriteRenderer>().color = (difficulty == PlayerPrefsManager.GetDifficulty()) ? new Color(255, 255, 255) : new Color(197, 197, 197, 0.5f);
    }

    void OnMouseDown()
    {
        PlayerPrefsManager.SetDifficulty(difficulty);
    }
}
