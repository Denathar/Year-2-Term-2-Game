using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider ManaBarUI;

    public int Mana;

    public int CurrentMana;

    public int manaRegen;

    public float RegenTime = 1.0f;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CurrentMana = Mana;
    }

    // Update is called once per frame
    void Update()
    {
        ManaBarUI.value = (float)CurrentMana / (float)Mana;

        if (CurrentMana <= 0)
        {
            BroadcastMessage("NoMana");

        }

        if (CurrentMana >= 0)
        {
            BroadcastMessage("HasMana");
        }

        if (CurrentMana >= Mana)
        {
            StopManaRegen();
        }

        if (timer >= RegenTime)
        {
            timer -= RegenTime;

            RegenMana();
        }
        timer += Time.deltaTime;

        if (CurrentMana >= Mana)
        {
            CurrentMana = Mana;
        }
    }

    void RegenMana()
    {
        CurrentMana += manaRegen;
    }

    void StopManaRegen()
    {
        timer = 0;
    }

    void UseMana(int amount)
    {
        CurrentMana -= amount;
        timer = 0;
    }
}
