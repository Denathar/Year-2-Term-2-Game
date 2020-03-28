using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrig : MonoBehaviour
{

    bool ison;
    // Bool is true false / on or off. is adjective
    public Light lightSource;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            ison = !ison;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            ison = !ison;

        }
    }


    // Update is called once per frame
    void Update()
    {
        lightSource.enabled = ison;
    }
}
