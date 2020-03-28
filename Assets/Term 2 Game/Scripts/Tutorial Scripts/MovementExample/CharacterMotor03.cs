using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only applying gravity while in air
public class CharacterMotor03 : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float newXDirecton = Input.GetAxis("Horizontal") * speed;
        moveDirection = new Vector3(newXDirecton, moveDirection.y, 0.0F);

        if (characterController.isGrounded)
        {            
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }        

        characterController.Move(moveDirection * Time.deltaTime);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0F);
    }
}
