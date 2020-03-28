using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIMove : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.zero;
    public Rigidbody characterController;
    public Transform target;
    public float speed = 2.0f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        moveDirection = transform.TransformDirection(new Vector3(0.0f, 0.0f, speed));

        characterController.velocity = (moveDirection * Time.deltaTime);

        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }



}
