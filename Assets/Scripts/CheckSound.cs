using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSound : MonoBehaviour {

    AudioSource[] checkSE; 

    private void Start()
    {
        checkSE = GetComponents<AudioSource>();
    }

    public void PlayCheckSound(int index)
    {
        checkSE[index].PlayOneShot(checkSE[index].clip);
    }
}
