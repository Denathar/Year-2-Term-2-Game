using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool ison = false;
    // Bool is true false / on or off. is adjective.
    Light lightSource;

    // Use this for initialization 
    void Start()
    {
        lightSource = GetComponent<Light>();
        // Tells script what component to use from unity
    }

    
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("f"))
        {
            ison = !ison;
            //lightSource.enabled = ison; Short hand for if ison == true
        }

		if (ison == true)
           
         
        {
            lightSource.enabled = true;
        }
        else
        {
            lightSource.enabled = false;
        }
     
	}
}
