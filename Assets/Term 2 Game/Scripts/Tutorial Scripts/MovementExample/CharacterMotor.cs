using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    CharacterController characterController;

    public float runSpeed = 10.0f;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float friction = 10.0F;
    public float drag = 10.0F;
    public float gravity = 20.0f;
    public int maxJumps = 1;

    private float currentSpeed;
    private int jumpCount;

    private Vector3 moveDirection;

    private Vector3 currentForce;
    private Vector3 currentForceVelocity;        

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {               
        if(characterController.collisionFlags == CollisionFlags.Sides)
        {
            jumpCount = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        moveDirection.x = Input.GetAxis("Horizontal") * currentSpeed;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity* Time.deltaTime;
        }
        else
        {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            if(characterController.collisionFlags == CollisionFlags.Sides)
            {
                Vector3 point1 = characterController.transform.position;
                point1.y += (characterController.height / 2) - characterController.radius;
                Vector3 point2 = characterController.transform.position;
                point2.y -= (characterController.height / 2) - characterController.radius;

                RaycastHit hit;

                if(Physics.CapsuleCast(point1, point2, characterController.radius, -characterController.transform.right, out hit, 0.1F))
                {
                    
                }
                else if(Physics.CapsuleCast(point1, point2, characterController.radius, characterController.transform.right, out hit, 0.1F))
                {
                    
                }
            }
            moveDirection.y = jumpSpeed;
            jumpCount++;
        }        

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void LateUpdate()
    {
        currentForce.x = ConsumeForce(currentForce.x, drag, Time.deltaTime, ref currentForceVelocity.x);
        currentForce.y = ConsumeForce(currentForce.y, drag, Time.deltaTime, ref currentForceVelocity.y);
        currentForce.z = ConsumeForce(currentForce.z, drag, Time.deltaTime, ref currentForceVelocity.z);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0F);
    }

    public void AddForce(float force, Vector3 direction)
    {
        currentForce += direction.normalized * force;
    }

    private float ConsumeForce(float force, float drag, float deltaTime, ref float forceVelocity)
    {
        return Mathf.SmoothDamp(force, 0.0F, ref forceVelocity, drag * deltaTime);
    }
}
