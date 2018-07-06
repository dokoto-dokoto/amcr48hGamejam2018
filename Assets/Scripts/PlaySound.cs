using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    AudioSource sound;
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && GameSystem.isPlayGame)
        {
            sound.PlayOneShot(sound.clip);
        }
	}
}
