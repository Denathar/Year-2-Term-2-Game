using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBoxMove : MonoBehaviour
{
    public GameObject Player;
    
    public Rigidbody PlayerRB;
    public Collider PickupColl;
    public TargetTag targetTag;


    public Transform Target;
    public Rigidbody TargetRB;

    public bool KeyMove = false;
    bool UiHBoxMove = false;

    private void Update()
    {
        if (Target != null)
        {
            

            if (Input.GetKey("e"))
            {
                KeyMove = true;

                TargetRB.velocity = PlayerRB.velocity;
                
            }
            if (Input.GetKeyUp("e"))
            {
                
                Target = null;
                PickupColl.enabled = true;
                TargetRB.isKinematic = true;
                Player.SendMessage("JumpSwitch", true);
                Player.SendMessage("turningSwitch", true);
                TargetRB = null;
                KeyMove = false;
            }
            if (KeyMove == false)
            {
                if (UiHBoxMove == true)
                {
                    TargetRB.velocity = PlayerRB.velocity;
                }
                if (UiHBoxMove == false)
                {
                    Target = null;
                    PickupColl.enabled = true;
                    if (TargetRB != null)
                    {
                        TargetRB.isKinematic = true;
                    }
                    Player.SendMessage("JumpSwitch", true);
                    Player.SendMessage("turningSwitch", true);
                    TargetRB = null;
                }
            }
            
        }




    }



    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            if (Input.GetKey("e"))
            {
                Player.SendMessage("SpeedChange", 1);
                Player.SendMessage("JumpSwitch", false);
                Player.SendMessage("turningSwitch", false);

                Target = other.transform;
                TargetRB = Target.GetComponent<Rigidbody>();

                TargetRB.isKinematic = false;
                PickupColl.enabled = false;

            }
            if (UiHBoxMove == true)
            {
                Player.SendMessage("SpeedChange", 1);
                Player.SendMessage("JumpSwitch", false);
                Player.SendMessage("turningSwitch", false);

                Target = other.transform;
                TargetRB = Target.GetComponent<Rigidbody>();

                PickupColl.enabled = false;

                TargetRB.isKinematic = false;
            }

        }
    }

    public void UiMoveHeavyBoxDown()
    {
        UiHBoxMove = true;
    }
    public void UiMoveHeavyBoxUp()
    {
        UiHBoxMove = false;
    }
}
