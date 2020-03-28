using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public TargetTag Enemy;
    public TargetTag Wall;
    public TargetTag Floor;

    public GameObject ExplosionPrefab;
    public Transform Epicenter;

    public float Size;

    public bool DetonateInAir;

    public float FlightTime = 1f;

    // public float ExplosionDamage;

    void Update()
    {
        if (DetonateInAir == true)
        {
            FlightTime -= Time.deltaTime;

            if (FlightTime < 0)
            {
                GameObject newObject = Instantiate(ExplosionPrefab, Epicenter.transform.position, Epicenter.transform.rotation);

                newObject.transform.localScale = new Vector3(Size, Size, Size);

                Destroy(gameObject);

                if (transform.Find("Particle System") != null)
                {
                    BroadcastMessage("Particals");
                }

                
            }
      
        }

    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Enemy.ToString())
        {

            EnemyHealth script4 = other.gameObject.GetComponent<EnemyHealth>();
            PlayerHealth script5 = other.gameObject.GetComponent<PlayerHealth>();

            if (script4 != null || script5 != null)
            {
  
                GameObject newObject = Instantiate(ExplosionPrefab, Epicenter.transform.position, Epicenter.transform.rotation);

                newObject.transform.localScale = new Vector3(Size, Size, Size);

                Destroy(gameObject);

                if (transform.Find("Particle System") != null)
                {
                    BroadcastMessage("Particals");
                }
            }
            


            //Damager script = gameObject.GetComponent<Damager>();

            //if (script != null)
            //{
            //    newObject.SendMessage("importDamage", ExplosionDamage);
            //}

            //TriggerDamager script2 = gameObject.GetComponent<TriggerDamager>();

            //if (script2 != null)
            //{
            //    newObject.SendMessage("importDamage", ExplosionDamage);
            //}
        }

        if (other.gameObject.tag == Wall.ToString() || other.gameObject.tag == Floor.ToString())
        {
            GameObject newObject = Instantiate(ExplosionPrefab, Epicenter.transform.position, Epicenter.transform.rotation);

            newObject.transform.localScale = new Vector3(Size, Size, Size);

            Destroy(gameObject);

            if (transform.Find("Particle System") != null)
            {
                BroadcastMessage("Particals");
            }
        }
    }

}
