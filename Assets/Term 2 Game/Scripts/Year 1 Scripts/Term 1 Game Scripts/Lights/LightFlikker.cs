using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlikker : MonoBehaviour {

    public Animator animator;
    public Animator animator2;


    // public float timer = 0.3f;


    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Flicker");
        animator2.SetTrigger("Flicker");
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Invoke("TurnOffLight", timer);
    }

    void TurnOffLight(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);

        }
    }*/


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
