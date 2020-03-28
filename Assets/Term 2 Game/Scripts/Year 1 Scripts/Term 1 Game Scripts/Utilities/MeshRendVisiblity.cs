using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendVisiblity : MonoBehaviour {

    public Renderer Visiblity;
    public bool visible = true;
    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            visible = !visible;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            visible = !visible;

        }
    }
    // Update is called once per frame
    void Update ()
    {
        Visiblity.enabled = visible;
    }
}
