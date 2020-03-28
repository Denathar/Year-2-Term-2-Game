using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int currentHealth;
    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected  float HealthDegradeTimer = 0.0f;

    //float timer = 0.0f;

    //public int HealthDegradeAmount;

    //public float OverHealthDegradeTime = 1.0f;

    //float damageTime = 1.0f;

    //public float DamageOverTime;

    //int DoTDamageIn;

    //bool isOn = false;



    private void Start()
    {
        currentHealth = health;

    }

    //void Update()
    //{


    //    if (isOn == true)
    //    {
    //        if (timer >= damageTime)
    //        {
    //            timer -= damageTime;

    //            TakeDamage(DoTDamageIn);
    //        }
    //        timer += Time.deltaTime;


    //        DamageOverTime -= Time.deltaTime;
    //        if (DamageOverTime < 0)
    //        {
    //            DamageOverTimeStop();
    //        }
    //    }

    //    HealthDegridation();
    //}
    //void PerSec(int PerSecIn)
    //{
    //    damageTime = PerSecIn;
    //}
    //void DamageIn(int DoTAmount)
    //{
    //    DoTDamageIn = DoTAmount;  
    //}
    //void DoTDuration(int Duration)
    //{
    //    DamageOverTime = Duration;
    //}
    //void DoTisOn()
    //{
    //    isOn = true;
    //}
    //void DamageOverTimeStop()
    //{
    //    timer = 0;
    //    DoTDamageIn = 0;
    //    isOn = false;
    //}

    //public void HealthDegridation()
    //{
    //    if (currentHealth >= health)
    //    {
    //        if (HealthDegradeTimer >= OverHealthDegradeTime)
    //        {
    //            HealthDegradeTimer -= OverHealthDegradeTime;

    //            TakeDamage(HealthDegradeAmount);
    //        }
    //        HealthDegradeTimer += Time.deltaTime;
    //    }

    //    if (currentHealth <= health)
    //    {
    //        HealthDegradeTimer = 0;
    //    }

    //}

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        HealthDegradeTimer = 0;


        if (currentHealth == 0)
        {
            Die();
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
