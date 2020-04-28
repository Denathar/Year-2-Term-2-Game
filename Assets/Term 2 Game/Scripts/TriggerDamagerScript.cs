using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamagerScript : MonoBehaviour
{
    public TargetTag targetTag;
    public TargetTag targetTag2;
    public int damage;
    public bool HealingObject;
    public bool StaminaDamage;
    public bool HealthDamage;

    public bool OnStay;
    public float StayTimer = 0.1f;

    private GameObject target;
    public GameObject RootObject;

    public AudioSource HitAudio;

    public void Start()
    {
        if (HealingObject == true)
        {
            damage = -damage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString())
        {
            HealthScript script = other.gameObject.GetComponent<HealthScript>();
            StaminaScript script2 = other.gameObject.GetComponent<StaminaScript>();
            if (script != null)
            {
                if (HealthDamage == true)
                {
                    //Debug.Log("Take Damage");
                    if (OnStay == true)
                    {
                        InvokeRepeating("SendDamage", 0f, StayTimer);
                        target = other.gameObject;

                        if (HealingObject == true)
                        {
                            RootObject.GetComponent<Animator>().SetBool("IsAbsorbing", true);
                        }

                    }
                    else
                    {
                        other.gameObject.SendMessage("TakeDamage", damage);
                        HitAudio.Play();
                    }
                }
               
            }
            if (script2 != null)
            {
                if (StaminaDamage == true)
                {
                    if (OnStay == true)
                    {
                        InvokeRepeating("SendStaminaDamage", 0f, StayTimer);
                        target = other.gameObject;
                        if (HealingObject == true)
                        {
                            RootObject.GetComponent<Animator>().SetBool("IsAbsorbing", true);
                        }
                    }
                    else
                    {
                        other.gameObject.SendMessage("RemoveStamina", damage);
                    }
                }
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString())
        {
            HealthScript script = other.gameObject.GetComponent<HealthScript>();
            StaminaScript script2 = other.gameObject.GetComponent<StaminaScript>();
            if (script != null)
            {

                CancelInvoke("SendDamage");

                if (HealingObject == true)
                {
                    RootObject.GetComponent<Animator>().SetBool("IsAbsorbing", false);
                }

            }
            if (script2 != null)
            {

                CancelInvoke("SendStaminaDamage");

                if (HealingObject == true)
                {
                    RootObject.GetComponent<Animator>().SetBool("IsAbsorbing", false);
                }

            }
        }

    }

    void SendDamage()
    {
        target.gameObject.SendMessage("TakeDamage", damage);
    }

    void SendStaminaDamage()
    {
        target.gameObject.SendMessage("RemoveStamina", damage);
    }

    void Update()
    {


        if (target != null)
        {
            HealthScript script = target.gameObject.GetComponent<HealthScript>();
            StaminaScript script2 = target.gameObject.GetComponent<StaminaScript>();
            if (script != null)
            {
                if (HealthDamage == true)
                {
                    if (target.GetComponent<HealthScript>().currentHealth >= target.GetComponent<HealthScript>().health)
                    {
                        RootObject.GetComponent<Animator>().SetBool("IsAbsorbing", false);
                        CancelInvoke("SendDamage");
                    }
                } 
            }
            if (script2 != null)
            {
                if (StaminaDamage == true)
                {
                    if (target.GetComponent<StaminaScript>().CurrentStamina >= target.GetComponent<StaminaScript>().Stamina)
                    {
                        RootObject.GetComponent<Animator>().SetBool("IsAbsorbing", false);
                        CancelInvoke("RemoveStamina");
                    }
                }

            }

        }
    }
}
