using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public CharacterController characterController;
    public Animator characterAnimator;

    public float runSpeed = 10.0f;
    public float speed = 6.0f;
    public float InitailSpeed = 6.0f;
    public float finalSpeed;
    public float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 TurnDirection = Vector3.zero;
    public float Horizontal;
    public float InverseHorizontal;
    public bool Blocking;

    void Start()
    {
        characterAnimator.applyRootMotion = false;
        moveDirection = new Vector3(0f,0f,1f);
        InitailSpeed = speed;
    }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        InverseHorizontal = -Horizontal;
        finalSpeed = speed;
        moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")));
        moveDirection *= finalSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        if (Input.GetButtonDown("A Button"))
        {
            speed = runSpeed;
        }
        if (Input.GetButtonUp("A Button"))
        {
            speed = InitailSpeed;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        TurnDirection = new Vector3(Input.GetAxis("Mouse X"), 0.0f, 0.0f);
        Vector3 characterRotation = Player.transform.rotation.eulerAngles;
        if (TurnDirection.x > 0)
        {
            characterRotation.y = characterRotation.y + TurnDirection.x * 200.0f * Time.deltaTime;
        }
        if (TurnDirection.x < 0)
        {
            characterRotation.y = characterRotation.y + TurnDirection.x * 200.0f * Time.deltaTime;
        }
        Player.transform.rotation = Quaternion.Euler(characterRotation);
        if (Blocking == false)
        {
            characterAnimator.SetFloat("Speed-x", Input.GetAxis("Horizontal"));
            characterAnimator.SetFloat("Speed-z", Input.GetAxis("Vertical"));
        }
        else
        {
            characterAnimator.SetFloat("Speed-x", Input.GetAxis("Horizontal") * 0.75f);
            characterAnimator.SetFloat("Speed-z", Input.GetAxis("Vertical") * 0.75f);
        }
        characterAnimator.SetFloat("TurnDir", Input.GetAxis("Mouse X"));
    }
}
