using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
     public Flashlight2 playerLight;

    bool interactable = false;

    private void OnTriggerEnter(Collider other)
    {
         interactable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = false;
    }
 
    // Update is called once per frame
    void Update ()
    {
        if (interactable == true && Input.GetKeyDown("e"))
        {
            playerLight.ResetBattery();
            Destroy(gameObject);
        }
    }
}
