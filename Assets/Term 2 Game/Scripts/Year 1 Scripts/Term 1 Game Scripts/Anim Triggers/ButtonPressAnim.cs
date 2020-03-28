using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnim : MonoBehaviour
{
    
    public Animator animator;
    bool Switch;
    


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("f"))
        {
            Switch = !Switch;
            animator.SetBool("Switch", Switch);

        }
	}
}
