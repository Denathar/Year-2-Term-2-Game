using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
   
    bool ison;
    // Bool is true false / on or off. is adjective
    public Light lightSource;

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown("e"))
        {
            ison = !ison;
        }
    }
    // Update is called once per frame
    void Update ()
    {
        lightSource.enabled = ison;
    }
}
