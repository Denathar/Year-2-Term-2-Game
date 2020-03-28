using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisperAudioTrigger : MonoBehaviour
{
   public AudioSource soundFX;
   public Collider trigger;

	// Use this for initialization
	void Start ()
    {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        //soundFX.Play(); for all objects

        if(other.gameObject.tag == "Player")
        {
            soundFX.Play(); // only triggers if player walks through the collider
            trigger.enabled = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
