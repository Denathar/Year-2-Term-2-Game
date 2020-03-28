using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Climbing ladders
public class CharacterMotor05 : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float runSpeed = 10.0f;
    public float climbSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public int maxJumps = 2;

    private Vector3 moveDirection = Vector3.zero;
    private float currentSpeed = 0.0F;
    private int currentJumps = 0;

    private bool canClimb;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        float newXDirecton = Input.GetAxis("Horizontal") * currentSpeed;
        float newYDirecton = moveDirection.y;

        if (canClimb)
        {
            newYDirecton = Input.GetAxis("Vertical") * climbSpeed;
        }

        moveDirection = new Vector3(newXDirecton, newYDirecton, 0.0F);                

        if (characterController.isGrounded)
        {
            currentJumps = 0;
        }
        else if(!canClimb)
        {            
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps && !canClimb)
        {
            moveDirection.y = jumpSpeed;
            currentJumps++;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0F);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            canClimb = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            canClimb = false;
        }
    }
}
