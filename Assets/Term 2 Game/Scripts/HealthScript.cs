﻿using System.Collections;
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
    public Collider HitBoxcolider;
    public Collider Damagecolider;
    public GameObject canvas;
    public GameObject enemymesh;
    public GameObject enemy;
    public bool GrantsVictory = false;
    public GameObject Center;
    public GameObject VictoryScreen;
    public AudioSource WoundAudio;
    public AudioSource WoundAudio2;
    public AudioSource SwordAudio;
    public AudioSource DeathAudio;
    public AudioSource Healing;
    public AudioSource Block;



    


    private void Start()
    {
        Player = gameObject;
        RootPlayer = GameObject.FindGameObjectWithTag("Player");

        animators = GetComponentsInChildren<Animator>();

        DeathAudio.enabled = false;

    }
    public void Update()
    {
        //base.Update();
        HealthBar.value = (float)currentHealth / (float)health;

        if (IsPlayer == true)
        {
            foreach (Animator animator in animators)
            {
                animator.SetFloat("NormalizedTime", (float)currentHealth / health);
                animator.SetBool("IsPlayer", true);
            }


        }
        else
        {
            foreach (Animator animator in animators)
            {
                if(animators[0] != null)
                {
                    animator.SetBool("IsPlayer", false);
                }
                
            }

        }

        if (currentHealth <= 0)
        {
            Die();
            
            
        }
        if (currentHealth >= health)
        {
            currentHealth = health;

        }


        if (RegenOn == true)
        {
            if (currentHealth >= health / 2)
            {
                StopHealthRegen();
            }
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
    
    public void TakeDamage(int amount)
    {
        if (CanTakeDmg == true)
        {
            currentHealth -= amount;
            timer = -5;


            if (currentHealth < health)
            {
                if (amount > 0)
                {
                    if (WoundAudio != null)
                    {
                        WoundAudio.Play();
                    }
                    if (WoundAudio2 != null)
                    {
                        WoundAudio2.Play();
                    }
                    if (SwordAudio != null)
                    {
                        SwordAudio.Play();
                    }
                }
                else
                {
                    Healing.enabled = true;

                }
            }
            if (currentHealth == health)
            {

                Healing.enabled = false;
            }
            if (IsPlayer == false)
            {
                if (gameObject.GetComponent<NavMesh>() != null)
                {
                    gameObject.GetComponent<NavMesh>().Attacking = true;
                }
            }

        }
        else
        {
            Block.Play();
            SwordAudio.Play();
        }
    }

    public void StopAudio()
    {
        Healing.enabled = false;
    }

    void RegenHealth()
    {
        currentHealth += HealthRegen;

    }

    void StopHealthRegen()
    {
        timer = 0;
    }

    public void Die()
    {

        if (DeathAudio != null)
        {
            DeathAudio.playOnAwake = true;
            DeathAudio.enabled = true;
        }

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
            if (animators[0] != null)
            {
                animator.enabled = true;
            }

        }
        if (HitBoxcolider != null)
        {
            HitBoxcolider.enabled = false;
        }
        if (Damagecolider != null)
        {
            Damagecolider.enabled = false;

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
            if (enemy.GetComponent<NavMesh>() != null)
            {
                if (enemy.GetComponent<NavMesh>().enabled == true)
                {
                    enemy.GetComponent<NavMesh>().Index();
                }
                enemy.GetComponent<NavMesh>().enabled = false;
                

            }
            if (enemy.GetComponent<SimpleAIMove>() != null)
            {
                enemy.GetComponent<SimpleAIMove>().enabled = false;
            }
            enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        }
        if (Center == null)
        {
            if (GrantsVictory == true)
            {
                VictoryScreen.SetActive(true);
            }
        }



    }
}
