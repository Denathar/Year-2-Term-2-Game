using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    public float ExplosionTime;

    float DissapperTime;

    float ExplosionDamage;

    public bool SizeDamage;

    private void Start()
    {
        ExplosionTime = transform.localScale.y;
        DissapperTime = ExplosionTime;
        ExplosionDamage = DissapperTime * 5;
    }
    void Update()
    {

        ExplosionTime -= Time.deltaTime * DissapperTime;



        if (ExplosionTime < 0)
        {
            Destroy(gameObject);
        }

        transform.localScale = new Vector3(ExplosionTime, ExplosionTime, ExplosionTime);

        if (SizeDamage == true)
        {
            Damager script = gameObject.GetComponent<Damager>();

            if (script != null)
            {
                gameObject.SendMessage("importDamage", ExplosionDamage);
            }

            TriggerDamager script2 = gameObject.GetComponent<TriggerDamager>();

            if (script2 != null)
            {
                gameObject.SendMessage("importDamage", ExplosionDamage);
            }
        }


    }

}
