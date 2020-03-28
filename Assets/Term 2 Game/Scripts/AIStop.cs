using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStop : MonoBehaviour
{

    public TargetTag targetTag;
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            Enemy.GetComponent<NavMeshAgent>().enabled = false;

            Debug.Log("Stop");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            Enemy.GetComponent<NavMeshAgent>().enabled = true;

            Debug.Log("Start");
        }
    }

}
