using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisablity : MonoBehaviour
{

    public Color color;

    void OnTriggerStay(Collider other)
    {
        Color color = GetComponent<Renderer>().material.color;

        

        color.a += 100f;


        GetComponent<Renderer>().material.color = color;

    }
}
