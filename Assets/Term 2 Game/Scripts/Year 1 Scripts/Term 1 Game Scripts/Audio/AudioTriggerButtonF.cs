using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerButtonF : MonoBehaviour
{
    public AudioSource Effect;
   
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
            
        {
            Effect.Play();
        }
        

      
    }

  
}
