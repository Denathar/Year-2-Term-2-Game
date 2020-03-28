using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wall jumping
public class CharacterMotor07 : MonoBehaviour
{
    CharacterController characterController;

    public float acceleration = 60.0F;
    public float airAcceleration = 30.0F;
    public float speed = 6.0f;
    public float runSpeed = 10.0f;
    public float climbSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float drag = 10.0F;
    public float friction = 10.0F;
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
        if (characterController.collisionFlags == CollisionFlags.Sides)
        {
            currentJumps = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        float newXDirecton = moveDirection.x;

        if(newXDirecton != 0.0F)
        {
            float finalDrag = drag;
            if (characterController.isGrounded)
            {
                finalDrag += friction;
            }

            if(newXDirecton > 0.0F)
            {
                newXDirecton = Mathf.Max(newXDirecton - (finalDrag * Time.deltaTime), 0.0F);
            }
            else
            {
                newXDirecton = Mathf.Min(newXDirecton + (finalDrag * Time.deltaTime), 0.0F);
            }
        }

        float finalAccel = acceleration;
        if (!characterController.isGrounded)
        {
            finalAccel = airAcceleration;
        }

        if (newXDirecton > -currentSpeed && newXDirecton < currentSpeed)
        {
            newXDirecton = Mathf.Clamp(newXDirecton + (Input.GetAxis("Horizontal") * (finalAccel * Time.deltaTime)), -currentSpeed, currentSpeed);
        }

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
            if (characterController.collisionFlags == CollisionFlags.Sides)
            {
                Vector3 point1 = characterController.transform.position;
                point1.y += (characterController.height / 2) - characterController.radius;
                Vector3 point2 = characterController.transform.position;
                point2.y -= (characterController.height / 2) - characterController.radius;

                RaycastHit hit;

                if (Physics.CapsuleCast(point1, point2, characterController.radius, -characterController.transform.right, out hit, 0.1F))
                {
                    moveDirection.x = jumpSpeed;
                }
                else if (Physics.CapsuleCast(point1, point2, characterController.radius, characterController.transform.right, out hit, 0.1F))
                {
                    moveDirection.x = -jumpSpeed;
                }
            }
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
