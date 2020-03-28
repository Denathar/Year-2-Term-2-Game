using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    
    public Collider PlayerCol;

    

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private float PlayerY = 1f;

    public float Position = 0;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(Position, PlayerY, 0f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (Input.GetKeyDown("d"))
        {
            if (Position == 0f)
            {
                Position = 2.5f;
            }

            if (Position == -2.5)
            {
                Position = 0f;
            }
        }

        if (Input.GetKeyDown("a"))
        {
            if (Position == 0f)
            {
                Position = -2.5f;
            }

            if (Position == 2.5)
            {
                Position = 0f;
            }
        }

        if (PlayerCol.enabled == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                PlayerY = jumpSpeed;

            }
        }
        

        if (PlayerY > 1)
        {
            PlayerY -= gravity * Time.deltaTime;
        }
        if (PlayerY < 1)
        {
            PlayerY = 1;
        }
    }
}
