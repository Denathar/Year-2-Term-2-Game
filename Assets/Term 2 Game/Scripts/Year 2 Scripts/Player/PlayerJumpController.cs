using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    public GameObject PickUpCollider;
    public TargetTag targetTag;
    public TargetTag targetTag2;
    public TargetTag targetTag3;
    public TargetTag targetTag4;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString() || other.gameObject.tag == targetTag3.ToString() || other.gameObject.tag == targetTag4.ToString())
        {
            gameObject.SendMessageUpwards("JumpSwitch", true);
            PickUpCollider.SendMessage("DropSwitch", false);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.SendMessageUpwards("JumpSwitch", false);
    }


}
