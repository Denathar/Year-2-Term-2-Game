using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    public bool IceEnemy;
    public bool FireEnemy;


    public int ScoreValue;

    public Slider HealthBar;
    public Slider OverHealthBar;

    public int DropPicker;

    public GameObject Drop;
    public GameObject Drop2;
    public GameObject Drop3;
    public Transform DropLocation;

    public override void Die()
    {
        GameObject.Find("ScoreManger").GetComponent<ScoreManager>().AddToScore(ScoreValue);

        base.Die();
        if (Drop != null && DropLocation != null)
        {
            if (DropPicker == 1)
            {
                Instantiate(Drop, DropLocation.transform.position, DropLocation.transform.rotation);
            }
  
        }
        if (Drop2 != null && DropLocation != null)
        {
            if (DropPicker == 2)
            {
                Instantiate(Drop2, DropLocation.transform.position, DropLocation.transform.rotation);
            }

        }
        if (Drop3 != null && DropLocation != null)
        {
            if (DropPicker == 3)
            {
                Instantiate(Drop3, DropLocation.transform.position, DropLocation.transform.rotation);
            }

        }
    }

   

    public Text OnFire;

    float timer = 0.0f;

    public int HealthDegradeAmount;

    public float OverHealthDegradeTime = 1.0f;

    float damageTime = 1.0f;

    public float DamageOverTime;

    int DoTDamageIn;

    bool isOnFire = false;

    public Image HealthFill;
    public Image BGHealthFill;
    public Image overHealthFill;



    private void Update()
    {
        HealthBar.value = (float)currentHealth / (float)health;

        OverHealthBar.value = (float)currentHealth / (float)maxHealth;

        

        if (OnFire != null)
        {
            if (isOnFire == true)
            {
                OnFire.enabled = true;
                

            }
            if (isOnFire == false)
            {
                OnFire.enabled = false;
            }
        }

        if (currentHealth == health)
        {

            HealthFill.enabled = false;
            BGHealthFill.enabled = false;
            overHealthFill.enabled = false;
        }

        else if (currentHealth >= health || currentHealth <= health)
        {
            HealthFill.enabled = true;
            BGHealthFill.enabled = true;
            overHealthFill.enabled = true;
        }

        if (isOnFire == true)
        {
            if (timer >= damageTime)
            {
                timer -= damageTime;

                TakeDamage(DoTDamageIn);
            }
            timer += Time.deltaTime;


            DamageOverTime -= Time.deltaTime;
            if (DamageOverTime < 0)
            {
                DamageOverTimeStop();
            }
        }

        HealthDegridation();


        if (DPTimer >= DPTime)
        {
            DPTimer -= DPTime;

            DropPicker = Random.Range(1, 4);
        }
        DPTimer += Time.deltaTime;



    }

    float DPTimer = 0;
    float DPTime = 1;

    void PerSec(int PerSecIn)
    {
        damageTime = PerSecIn;
    }
    void DamageIn(int DoTAmount)
    {
        DoTDamageIn = DoTAmount;
    }
    void DoTDuration(int Duration)
    {
        DamageOverTime = Duration;
    }
    void DoTisOn()
    {
        isOnFire = true;
    }
    void DamageOverTimeStop()
    {
        timer = 0;
        DoTDamageIn = 0;
        isOnFire = false;
    }

    public void HealthDegridation()
    {
        if (currentHealth >= health)
        {
            if (HealthDegradeTimer >= OverHealthDegradeTime)
            {
                HealthDegradeTimer -= OverHealthDegradeTime;

                TakeDamage(HealthDegradeAmount);
            }
            HealthDegradeTimer += Time.deltaTime;
        }

        if (currentHealth <= health)
        {
            HealthDegradeTimer = 0;
        }
    }
}
