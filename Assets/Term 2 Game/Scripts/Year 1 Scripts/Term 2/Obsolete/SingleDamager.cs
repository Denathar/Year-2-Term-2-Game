using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamager : MonoBehaviour
{
    public int damage;

    public TargetTag targetTag;

    //public string targetTag ="";

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            other.gameObject.SendMessage("TakeDamage", damage);
            
        }

    }
}
