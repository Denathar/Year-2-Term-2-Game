using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healingzone : MonoBehaviour
{
    public int damage;

   // public float timer = 0.3f;

    public string targetTag = "";

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            other.gameObject.SendMessage("TakeDamage", damage);
        }

        //InvokeRepeating("Heal", timer, timer);
        
    }

    void Heal()
    {
        
    }
}

