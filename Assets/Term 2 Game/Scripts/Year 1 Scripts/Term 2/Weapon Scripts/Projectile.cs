using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;

    public float FlightTime = 1f;

    public bool UseTimer;

    void Start()
    {
        
    }

    void Update()
    {

        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Speed;

        FlightTime -= Time.deltaTime;

        if(UseTimer == true)
        {
            if (FlightTime < 0)
            {
                if (transform.Find("Particle System") != null)
                {
                    BroadcastMessage("Particals");
                }
                Destroy(gameObject);

            }

        }



        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (transform.Find("Particle System") != null)
        {
            BroadcastMessage("Particals");
        }

        Destroy(gameObject);

        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //}
}
