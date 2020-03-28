using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisablityController : MonoBehaviour
{
    public MeshRenderer[] Objects;
    public TargetTag targetTag;
    

    private void Start()
    {
        Objects = GetComponentsInChildren<MeshRenderer>();

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            foreach (MeshRenderer Objects in Objects)
            {
                Objects.enabled = false;
            }
        }
        

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            foreach (MeshRenderer Objects in Objects)
            {
                Objects.enabled = true;
            }
        }
    }

}
