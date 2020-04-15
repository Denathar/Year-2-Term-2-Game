using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMove : MonoBehaviour
{
    public NavMeshAgent characterController;
    public Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        characterController = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (characterController.enabled == true)
        {
            characterController.destination = target.position;
        }
        
    }



}
