using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePenetration : MonoBehaviour
{
    public TargetTag Wall;
    public TargetTag Floor;
    public TargetTag Enemy;

    public float Speed;
    public int ObjectPenNumber;
    public int NumberOfPens;
    
    public bool DestroyOnWall;

    public float FlightTime = 1f;

    public bool UseTimer;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth script4 = other.gameObject.GetComponent<EnemyHealth>();
        PlayerHealth script5 = other.gameObject.GetComponent<PlayerHealth>();

        if (script4 != null || script5 != null)
        {

            if (other.gameObject.tag == Enemy.ToString() || other.gameObject.tag == Wall.ToString() || other.gameObject.tag == Floor.ToString())
            {
                NumberOfPens++;
            }
        }
        

        if (DestroyOnWall == true)
        {
            if (other.gameObject.tag == Wall.ToString())
            {
                if (transform.Find("Particle System") != null)
                {
                    BroadcastMessage("Particals");
                }
                Destroy(gameObject);
            }
        }


    }

    private void Update()
    {
        if (NumberOfPens >= ObjectPenNumber)
        {
            if (transform.Find("Particle System") != null)
            {
                BroadcastMessage("Particals");
            }
            Destroy(gameObject);

        }

        FlightTime -= Time.deltaTime;

        if (UseTimer == true)
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

}
