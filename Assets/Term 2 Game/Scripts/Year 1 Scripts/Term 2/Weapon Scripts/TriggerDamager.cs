using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
    public TargetTag targetTag;
    public TargetTag targetTag2;
    public TargetTag targetTag3;


    public bool Healing;

    public int damage;

    public int ManaDamage;

    public int StaminaDamage;

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

            ManaDamage = -ManaDamage;

            StaminaDamage = -StaminaDamage;

        }
    }


    //public string targetTag ="";

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString() || other.gameObject.tag == targetTag3.ToString())
        {
            if (SingleDamage == true)
            {
                Health script = other.gameObject.GetComponent<Health>();
                PlayerMovment script3 = other.gameObject.GetComponent<PlayerMovment>();
                ManaBar script2 = other.gameObject.GetComponent<ManaBar>();

                if (script != null)
                {
                    other.gameObject.SendMessage("TakeDamage", damage);
                    
                }

                
                if (script2 != null)
                {
                    other.gameObject.SendMessage("UseMana", ManaDamage);
                }

                
                if (script3 != null)
                {
                    other.gameObject.SendMessage("UseStamina", StaminaDamage);
                    
                }
            }

            EnemyHealth script4 = other.gameObject.GetComponent<EnemyHealth>();
            PlayerHealth script5 = other.gameObject.GetComponent<PlayerHealth>();

            if (script4 != null || script5 != null)
            {
                if (DamageOverTime == true)
                {

                    other.gameObject.SendMessage("DoTDuration", Duration);
                    other.gameObject.SendMessage("DoTisOn");
                    other.gameObject.SendMessage("DamageIn", DoTAmount);
                    other.gameObject.SendMessage("PerSec", PerSecIn);
                }
            }
      

            NavMeshEnemy script6 = other.gameObject.GetComponent<NavMeshEnemy>();
            if (script6 != null)
            {

                if (SlowEffect == true)
                {
                    other.gameObject.SendMessage("SlowEffect", SlowEffectAmount);
                    other.gameObject.SendMessage("SlowEffectDuration", SlowDurationIn);

                }

                if (StopsSlow == true)
                {

                    other.gameObject.SendMessage("SlowEffectStop");
                }


            }
            

            if (script4 != null || script5 != null)
            {
                if (StopsDamageOverTime == true)
                {

                    other.gameObject.SendMessage("DamageOverTimeStop");
                }
            }


        }

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString() || other.gameObject.tag == targetTag3.ToString())
        {
            if (ContinuousDamage == true)
            {
                PlayerMovment script3 = other.gameObject.GetComponent<PlayerMovment>();

                if (script3 != null)
                {
                    if (timer >= damageTime)
                    {
                        timer -= damageTime;

                        Health script = other.gameObject.GetComponent<Health>();
                        ManaBar script2 = other.gameObject.GetComponent<ManaBar>();


                        if (script != null)
                        {
                            other.gameObject.SendMessage("TakeDamage", damage);
                        }


                        if (script2 != null)
                        {
                            other.gameObject.SendMessage("UseMana", ManaDamage);
                        }

                        other.gameObject.SendMessage("UseStaminaMove", StaminaDamage);

                    }

                    timer += Time.deltaTime;



                    if (SlowEffect == true)
                    {
                        other.gameObject.SendMessage("SlowEffect", SlowEffectAmount);
                        other.gameObject.SendMessage("SlowEffectDuration", SlowDurationIn);

                    }

                    if (StopsSlow == true)
                    {

                        other.gameObject.SendMessage("SlowEffectStop");
                    }

                    EnemyHealth script4 = other.gameObject.GetComponent<EnemyHealth>();
                    PlayerHealth script5 = other.gameObject.GetComponent<PlayerHealth>();

                    if (script4 != null || script5 != null)
                    {
                        if (StopsDamageOverTime == true)
                        {

                            other.gameObject.SendMessage("DamageOverTimeStop");
                        }
                    }
                }

                


            }
            NavMeshEnemy script6 = other.gameObject.GetComponent<NavMeshEnemy>();
            if (script6 != null)
            {
                if (SlowEffect == true)
                {
                    other.gameObject.SendMessage("SlowEffect", SlowEffectAmount);
                    other.gameObject.SendMessage("SlowEffectDuration", SlowDurationIn);

                }
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        NavMeshEnemy script6 = other.gameObject.GetComponent<NavMeshEnemy>();
        if (script6 != null)
        {
            if (SlowZone == true)
            {
                other.gameObject.SendMessage("SlowEffectStop");
            }
        }

    }
    void importDamage(int InDamage)
    {
        damage = InDamage;
    }


}
