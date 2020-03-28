using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisperAudioTriggerPause : MonoBehaviour
{
   public AudioSource soundFX;

	// Use this for initialization
	void Start ()
    {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        //soundFX.Play(); for all objects

        if(other.gameObject.tag == "Player")
        {
            soundFX.Pause(); // only triggers if player walks through the collider
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
