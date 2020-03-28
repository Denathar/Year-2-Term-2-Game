using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupTest : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter(Collision collision)
    {
        animator.enabled = true;
    }
}
