using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSetUp : MonoBehaviour
{

    public Text Score;
    public GameObject NuevoRecord;

    // Use this for initialization
    void Start()
    {

        NuevoRecord.gameObject.SetActive(false);
        Score.text = Mathf.Floor(Move.score).ToString();

        if (Move.score > PlayerPrefsManager.GetScore())
        {
            NuevoRecord.SetActive(true);

            PlayerPrefsManager.SetScore(Move.score);
        }
        Move.score = 0;
    }

    public void Load()
    {
        SceneManager.LoadScene("Credits");
    }
}
