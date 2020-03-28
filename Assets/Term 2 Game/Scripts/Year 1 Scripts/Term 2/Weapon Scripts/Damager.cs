using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public TargetTag targetTag;
    public TargetTag targetTag2;
    public TargetTag targetTag3;

    public bool Healing;

    public int damage;

    public bool SingleDamage;

    public bool ContinuousDamage;

    float timer = 0.0f;

    public float damageTime = 1.0f;

    public bool DamageOverTime;

    public int DoTAmount;

    public float PerSecIn = 1.0f;

    public float Duration;

    public bool SlowEffect;

    public bool SlowZone;

    public float SlowEffectAmount;

    public float SlowDurationIn;

    public bool StopsSlow;

    public bool StopsDamageOverTime;


    void Start()
    {
        if (Healing == true)
        {
            damage = -damage;
        }
    }

    //public string targetTag ="";

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString() || other.gameObject.tag == targetTag3.ToString())
        {
            if (SingleDamage == true)
            {
                Health script = other.gameObject.GetComponent<Health>();
                if (script != null)
                {
                    other.gameObject.SendMessage("TakeDamage", damage);
                }

                
            }
            

            if (DamageOverTime == true)
            {
                other.gameObject.SendMessage("DoTDuration", Duration);
                other.gameObject.SendMessage("DoTisOn");
                other.gameObject.SendMessage("DamageIn", DoTAmount);
                other.gameObject.SendMessage("PerSec", PerSecIn);

            }

            if (SlowEffect == true)
            {
                other.gameObject.SendMessage("SlowEffect", SlowEffectAmount);
                other.gameObject.SendMessage("SlowEffectDuration", SlowDurationIn);

            }

            if (StopsSlow == true)
            {

                other.gameObject.SendMessage("SlowEffectStop");
            }

            if (StopsDamageOverTime == true)
            {

                other.gameObject.SendMessage("DamageOverTimeStop");
            }
        }

    }

    private void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString() || other.gameObject.tag == targetTag3.ToString())
        {
            if (ContinuousDamage == true)
            {
                if (timer >= damageTime)
                {
                    timer -= damageTime;

                    Health script = other.gameObject.GetComponent<Health>();
                    if (script != null)
                    {
                        other.gameObject.SendMessage("TakeDamage", damage);
                    }
                }
                timer += Time.deltaTime;
            }

            if (SlowEffect == true)
            {
                other.gameObject.SendMessage("SlowEffect", SlowEffectAmount);
                other.gameObject.SendMessage("SlowEffectDuration", SlowDurationIn);

            }
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (SlowZone == true)
        {
            other.gameObject.SendMessage("SlowEffectStop");
        }
    }

    void importDamage(int InDamage)
    {
        damage = InDamage;
    }


}
