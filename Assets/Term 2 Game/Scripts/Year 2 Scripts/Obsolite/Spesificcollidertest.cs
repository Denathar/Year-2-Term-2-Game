using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spesificcollidertest : MonoBehaviour
{
    public Collider testCollider;
   

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Hit");
    }
}
