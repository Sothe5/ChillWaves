using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static float speed;
    public static float score = 0;

    void Start()
    {
        if (PlayerPrefsManager.GetDifficulty() == 1)
            speed = 0.08f;
        if (PlayerPrefsManager.GetDifficulty() == 0)
            speed = 0.14f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0) {

            transform.position += new Vector3(-speed, 0, 0);
            score += speed / 2;

        }
    }
}
