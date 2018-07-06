using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.sceneLoaded += sample;
	}

    private void sample(Scene scenename, LoadSceneMode SceneMode)
    {

    }

    void Update () {
        
	}
}
