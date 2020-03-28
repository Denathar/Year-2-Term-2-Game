using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioTriggerButton : MonoBehaviour
{
    public AudioSource Open;
    bool interactable = false;
    public AudioSource Turnoff;
    bool off = true;
   


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
            Open.Play();

            Invoke("Switch", 1);
            
            
        }

        Turnoff.enabled = off;
    }

    void Switch()
    {
        off = false;
        CancelInvoke();
    }
   
}
