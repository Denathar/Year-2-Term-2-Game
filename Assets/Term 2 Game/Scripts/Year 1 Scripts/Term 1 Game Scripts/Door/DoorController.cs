using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   
    public Animator animator;
    bool isOpen;
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);

        }
    }

}
