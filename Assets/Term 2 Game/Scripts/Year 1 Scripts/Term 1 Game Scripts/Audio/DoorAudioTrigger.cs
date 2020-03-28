using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioTrigger : MonoBehaviour
{
    public AudioSource Open;
    public AudioSource Close;

	// Use this for initialization
	void Start ()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        //soundFX.Play(); for all objects

        if(other.gameObject.tag == "Player")
        {
            Open.Play(); // only triggers if player walks through the collider
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //soundFX.Play(); for all objects

        if (other.gameObject.tag == "Player")
        {
            Close.Play(); // only triggers if player walks through the collider
        }

    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
