using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public Transform Target;
    public Collider PickupColl;
    

    public Transform HoldPos;
    public TargetTag targetTag;
    public TargetTag targetTag2;

    public bool pickedUp = false;

    public bool UIPickUpBox = false;

    public bool drop = false;

    private void Update()
    {
        if (Target != null)
        {
            Target.position = HoldPos.position;
            if (UIPickUpBox == false)
            {
                
                if (drop == false)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        Target.SetParent(transform);
                        pickedUp = !pickedUp;
                        
                    }
                    if (pickedUp == false)
                    {

                        Target.gameObject.SendMessage("ParentSwitch", true);
                        PickupColl.enabled = true;
                        Target = null;
                        PlayerRB.mass = 1;
                    }
                }
            }
            
            if (UIPickUpBox == true)
            {
                Target.SetParent(transform);
                
            }
           
        }

        
        

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString())
        {
            if (drop == false)
            {
                if (Input.GetKeyDown("e"))
                {
                    PlayerRB.mass = 1.5f;
                    Target = other.transform;


                    if (Target != null)
                    {
                        Target.gameObject.SendMessage("ParentSwitch", false);
                    }

                    PickupColl.enabled = false;

                }
                if (UIPickUpBox == true)
                {
                    Target = other.transform;
                }
            }
            

        }
    }
 
    public void Drop()
    {
        if (Target != null)
        {
            Target.gameObject.SendMessage("ParentSwitch", true);
            Target = null;
            

            PlayerRB.mass = 1;
            
            drop = true;
            PickupColl.enabled = true;
        }    
    }
    void DropSwitch(bool DSwitch)
    {
        drop = DSwitch;
    }

    public void UiPickUpBox()
    {
        if (Target != null)
        {
            UIPickUpBox = !UIPickUpBox;
        }
        
    }

}
