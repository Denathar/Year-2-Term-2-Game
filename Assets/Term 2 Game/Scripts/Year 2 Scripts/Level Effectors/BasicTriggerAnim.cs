using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTriggerAnim : MonoBehaviour
{
   
    public Animator animator;
    bool isOpen;

    public TargetTag targetTag;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            animator.enabled = true;
        }
        
    }



}
