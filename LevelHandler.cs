using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void LoadScene(string scene) {

        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
