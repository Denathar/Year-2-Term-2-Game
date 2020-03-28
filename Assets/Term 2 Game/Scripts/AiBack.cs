using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBack : MonoBehaviour
{
    public TargetTag targetTag;
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            Enemy.GetComponent<SimpleAIMove>().speed = -200.0f;

            Debug.Log("Back");
        }

        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            Enemy.GetComponent<SimpleAIMove>().speed = 0.0f;

            Debug.Log("Stop");
        }
    }
}
