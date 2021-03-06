﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    public Slider StaminaBar;
    public int Stamina;
    public int CurrentStamina;
    public GameObject Player;
    public GameObject Weapon;
    public bool StaminaDepleted = false;
    public bool RegenOn;
    public int StaminaRegen = 1;
    public float RegenTime = 1.0f;
    bool TimerOn = true;
    float timer = 0.0f;

    public Animator[] animators;

    public AudioSource StaminaAudio;


    public void Update()
    {
        foreach (Animator animator in animators)
        {
            animator.SetFloat("AuraNormalizedTime", (float)CurrentStamina / Stamina);
        }

        StaminaBar.value = (float)CurrentStamina / (float)Stamina;
        if (CurrentStamina <= 1)
        {
            StaminaDepleted = true;
        }
        if (CurrentStamina < 0)
        {
            CurrentStamina = 1;
        }
        if (CurrentStamina >= 20)
        {
            StaminaDepleted = false;
        }
        if (CurrentStamina >= Stamina)
        {
            CurrentStamina = Stamina;
        }
        if (RegenOn == true)
        {
            if (CurrentStamina >= Stamina / 2)
            {
                StopStaminaRegen();
            }
            if (timer >= RegenTime)
            {
                timer -= RegenTime;
                RegenStamina();
            }
            if (TimerOn == true)
            {
                timer += Time.deltaTime;
            }
        }
    }
    public void RemoveStamina(int amount)
    {
        if (StaminaDepleted == false)
        {
            CurrentStamina -= amount;
            timer = -3;

        }

        if (CurrentStamina < Stamina)
        {
            if (amount < 0)
            {
                StaminaAudio.enabled = true;

            }
        }
        if (CurrentStamina == Stamina)
        {
            StaminaAudio.enabled = false;
        }



    }
    public void StopAudio()
    {
        StaminaAudio.enabled = false;
    }
    void RegenStamina()
    {
        CurrentStamina += StaminaRegen;
    }
    void StopStaminaRegen()
    {
        timer = 0;
    }


}