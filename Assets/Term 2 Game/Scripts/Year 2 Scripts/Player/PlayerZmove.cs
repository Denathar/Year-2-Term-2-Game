using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZmove : MonoBehaviour
{
    public TargetTag targetTag;
    public bool Enable = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            other.gameObject.SendMessage("ZmoveSwitch", Enable);
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            other.gameObject.SendMessage("ZmoveSwitch", !Enable);
        }
        

    }


}
