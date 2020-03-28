using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Slider HealthBar;
    public Slider OverHealthBar;

    public Text OnFire;



    float timer = 0.0f;
    

    public int HealthDegradeAmount;

    public float OverHealthDegradeTime = 1.0f;

    float damageTime = 1.0f;

    public float DamageOverTime;

    int DoTDamageIn;

    bool isOn = false;

    private void Update()
    {
        HealthBar.value = (float)currentHealth / (float)health;

        OverHealthBar.value = (float)currentHealth / (float)maxHealth;

        if (isOn == true)
        {
            OnFire.enabled = true;
        }
        if (isOn == false)
        {
            OnFire.enabled = false;
        }
       
        if (isOn == true)
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
        if (currentHealth >= health)
        {
            HealthDegridation();
        }
        
    }


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
        isOn = true;
    }
    void DamageOverTimeStop()
    {
        timer = 0;
        DoTDamageIn = 0;
        isOn = false;
    }

    public void HealthDegridation()
    {

        if (HealthDegradeTimer >= OverHealthDegradeTime)
        {

            HealthDegradeTimer -= OverHealthDegradeTime;

            TakeDamage(HealthDegradeAmount);
        }
        HealthDegradeTimer += Time.deltaTime;


        if (currentHealth <= health)
        {
            HealthDegradeTimer = 0;
        }
    }

}
