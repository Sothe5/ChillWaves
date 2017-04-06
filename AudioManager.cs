using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // Use this for initialization
    private AudioSource myAudio;
	void Start () {
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = PlayerPrefsManager.GetVolume();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
