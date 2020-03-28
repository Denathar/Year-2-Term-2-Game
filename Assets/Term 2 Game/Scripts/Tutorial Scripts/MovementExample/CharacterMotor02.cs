using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enabling movement while jumping
public class CharacterMotor02 : MonoBehaviour
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
            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;
        }        

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
