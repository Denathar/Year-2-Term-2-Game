using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //public Animator WeaponAnim;
    //public GameObject AttackCollider;
    //bool Isblocking = false;
    public GameObject Player;

    public Animator characterAnimator;


    //public float StaminaUseTime = 1.0f;
    //float timer = 0.1f;

    //private bool RightTiggerAxisButton = false;
    //private bool LeftTriggerAxisButton = false;

    void FixedUpdate()
    {
        if (Player.GetComponent<StaminaScript>().StaminaDepleted == false)
        {
            characterAnimator.SetFloat("RightTriggerAxis", Input.GetAxis("Right Trigger"));
            characterAnimator.SetFloat("LeftTriggerAxis", Input.GetAxis("Left Trigger"));
            characterAnimator.SetBool("Blocking", Input.GetButton("Left Bumper"));


        }
        else
        {
            characterAnimator.SetFloat("RightTriggerAxis", 0);
            characterAnimator.SetFloat("LeftTriggerAxis", 0);
        }
            

        //    if (Player.GetComponent<StaminaScript>().StaminaDepleted == false)
        //    {
        //        if (Isblocking == false)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                WeaponAnim.Play("Weapon attack");
        //                Player.gameObject.SendMessage("RemoveStamina", 10);
        //            }
        //            if (Input.GetMouseButtonDown(1))
        //            {
        //                WeaponAnim.Play("Weapon Heavy Attack");
        //                Player.gameObject.SendMessage("RemoveStamina", 20);
        //            }

        //            if (Input.GetAxis("Right Trigger") != 0)
        //            {
        //                if (RightTiggerAxisButton == false)
        //                {
        //                    WeaponAnim.Play("Weapon attack");
        //                    Player.gameObject.SendMessage("RemoveStamina", 10);
        //                    RightTiggerAxisButton = true;
        //                }
        //            }
        //            if (Input.GetAxis("Right Trigger") == 0)
        //            {
        //                RightTiggerAxisButton = false;
        //            }

        //            if (Input.GetAxis("Left Trigger") != 0)
        //            {
        //                if (LeftTriggerAxisButton == false)
        //                {
        //                    WeaponAnim.Play("Weapon Heavy Attack");
        //                    Player.gameObject.SendMessage("RemoveStamina", 20);
        //                    LeftTriggerAxisButton = true;
        //                }
        //            }
        //            if (Input.GetAxis("Left Trigger") == 0)
        //            {
        //                LeftTriggerAxisButton = false;
        //            }
        //        }

        //        if (Input.GetMouseButton(2) || Input.GetButton("Right Bumper"))
        //        {
        //            WeaponAnim.Play("Weapon Block");
        //            //WeaponAnim.["MyAnimation"].time = 5.0;
        //            WeaponAnim.SetBool("Attacking", false);
        //            Isblocking = true;
        //            gameObject.GetComponent<HealthScript>().CanTakeDmg = false;

        //            if (Time.time > StaminaUseTime)
        //            {
        //                StaminaUseTime = Time.time + timer;

        //                Player.gameObject.SendMessage("RemoveStamina", 1);

        //            }


        //        }
        //        else
        //        {
        //            WeaponAnim.SetBool("Attacking", true);
        //            Isblocking = false;
        //            gameObject.GetComponent<HealthScript>().CanTakeDmg = true;
        //        }
        //    }
        //    else
        //    {
        //        WeaponAnim.SetBool("Attacking", true);
        //        Isblocking = false;
        //        gameObject.GetComponent<HealthScript>().CanTakeDmg = true;
        //    }
    }

}
