using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamager : MonoBehaviour
{
    public int damage;

    float timer = 0.0f;

    public float damageTime = 1.0f;

    public TargetTag targetTag;

    //public string targetTag ="";


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            //other.gameObject.SendMessage("TakeDamage", damage);
            if (timer >= damageTime)
            {
                timer -= damageTime;
                other.gameObject.SendMessage("TakeDamage", damage);
            }
            timer += Time.deltaTime;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            // Reset the damage timer
            timer = 0;
        }
    }
}
