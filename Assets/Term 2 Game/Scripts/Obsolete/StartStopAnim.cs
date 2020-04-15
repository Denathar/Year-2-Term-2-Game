using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopAnim : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;

    public TargetTag targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            anim1.enabled = false;
            anim2.enabled = false;
            anim3.enabled = false;
            anim4.enabled = false;
        }
           
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            anim1.enabled = true;
            anim2.enabled = true;
            anim3.enabled = true;
            anim4.enabled = true;
        }

    }
}
