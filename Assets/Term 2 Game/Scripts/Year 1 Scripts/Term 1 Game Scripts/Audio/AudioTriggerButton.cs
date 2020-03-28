using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerButton : MonoBehaviour
{
    public AudioSource Effect;
    bool interactable = false;
   

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (interactable == true && Input.GetKeyDown("e"))
        {
            Effect.Play();

            
            
            
        }

      
    }

  
}
