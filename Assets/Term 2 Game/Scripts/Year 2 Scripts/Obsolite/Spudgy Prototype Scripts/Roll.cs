using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public Renderer Sphrend;
    public Collider SphCol;
    public Renderer PlayerRend;
    public Collider PlayerCol;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            Sphrend.enabled = true;
            SphCol.enabled = true;
            PlayerRend.enabled = false;
            PlayerCol.enabled = false;
        }
        if (Input.GetKeyUp("s"))
        {
            Sphrend.enabled = false;
            SphCol.enabled = false;
            PlayerRend.enabled = true;
            PlayerCol.enabled = true;

        }
    }
}
