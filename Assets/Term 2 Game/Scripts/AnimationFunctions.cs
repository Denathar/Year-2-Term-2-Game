using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunctions : MonoBehaviour
{
    public GameObject Player;
    public int StaminaUsed;



    void RemoveStamina()
    {
        Player.SendMessage("RemoveStamina", StaminaUsed);
        Debug.Log("UseStamina");
    }

    void Blocking()
    {
        Player.GetComponent<HealthScript>().CanTakeDmg = false;
        Player.GetComponent<Movement>().speed = 1;
        Player.GetComponent<Movement>().Blocking = true;

    }
    void NotBlocking()
    {
        Player.GetComponent<HealthScript>().CanTakeDmg = true;
        Player.GetComponent<Movement>().speed = 3;
        Player.GetComponent<Movement>().Blocking = false;

    }

}
