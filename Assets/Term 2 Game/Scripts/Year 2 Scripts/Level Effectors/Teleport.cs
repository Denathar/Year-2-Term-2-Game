using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public TargetTag targetTag;
    public Transform Target;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            other.gameObject.transform.position = Target.position;
            
        }
        
    }
}
