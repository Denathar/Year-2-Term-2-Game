using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public bool IsPlayer;
    public Slider HealthBar;
    public int health;
    public int currentHealth;
    public GameObject Player;
    public bool CanTakeDmg = true;

    public bool RegenOn = false;
    public int HealthRegen = 1;
    public float RegenTime = 0.1f;
    bool TimerOn = true;
    float timer = 0.0f;
    public float RegenWaitTime = 2;

    Coroutine damageRegen = null;

    public bool GivesHealth = false;
    public bool GivesStamina = false;
    public int HealthAmount = 10;
    public int StaminaAmount = 10;

    public GameObject RootPlayer;

    public Animator[] animators;
    public Collider colider;
    public GameObject canvas;
    public GameObject enemymesh;
    public GameObject enemy;
 
    private void Start()
    {
        Player = gameObject;
        RootPlayer = GameObject.FindGameObjectWithTag("Player");


    }
    public void Update()
    {
        //base.Update();
        HealthBar.value = (float)currentHealth / (float)health;

        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth >= health)
        {
            currentHealth = health;
        }

        if (currentHealth >= health)
        {
            TimerOn = false;
            StopHealthRegen();
        }

        if (RegenOn == true)
        {
            if (currentHealth < health / 2)
            {
                if (timer >= RegenTime)
                {
                    timer -= RegenTime;

                    RegenHealth();
                }
                if (TimerOn == true)
                {
                    timer += Time.deltaTime;
                }
            }
            
        }
        
        

    }
    public void TakeDamage(int amount)
    {
        if (CanTakeDmg == true)
        {
            currentHealth -= amount;
            if (RegenOn == true)
            {
                TimerOn = false;
                StopHealthRegen();
                if (damageRegen != null)
                {
                    StopCoroutine(damageRegen);
                }
                damageRegen = StartCoroutine(startRegen());
            }
            if (IsPlayer == false)
            {
                gameObject.GetComponent<NavMesh>().Attacking = true;
            }
            
        } 
    }

    public void Die()
    {
        if (GivesStamina == true)
        {
            HealthScript script = RootPlayer.gameObject.GetComponent<HealthScript>();
            if (script != null)
            {
                RootPlayer.gameObject.SendMessage("RemoveStamina", -StaminaAmount);
            }
        }
        if (GivesHealth == true)
        {
            HealthScript script = RootPlayer.gameObject.GetComponent<HealthScript>();
            if (script != null)
            {
                RootPlayer.gameObject.SendMessage("TakeDamage", -HealthAmount);
            }
        }
        if (IsPlayer == true)
        {
            Player.SetActive(false);
        }
        foreach (Animator animator in animators)
        {
            animator.enabled = true;
        }
        if (colider != null)
        {
            colider.enabled = false;
        }
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
        if (enemymesh != null)
        {
            enemymesh.SetActive(false);
        }
        if (enemy != null)
        {
            enemy.GetComponent<NavMesh>().enabled = false;
        }



    }
    void RegenHealth()
    {
        currentHealth += HealthRegen;
    }

    void StopHealthRegen()
    {
        timer = 0;
    }

    IEnumerator startRegen()
    {
        yield return new WaitForSeconds(RegenWaitTime);
        damageRegen = null;
        TimerOn = true;
        Debug.Log("HealthRegenStarted");
    }
}
