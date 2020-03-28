using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    [SerializeField]
    private Rigidbody PlayerBody;

    public GameObject Player;

    public Vector3 Velocity;
    public Vector3 AngularVelocity;
    

    public float Speed;
    public float JumpForce;
    public float Gravity = 10f;

    public bool JumpOn = true;



    
    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = PlayerBody.velocity;
        AngularVelocity = PlayerBody.angularVelocity;

        if (Input.GetButton("Horizontal"))
        {
            PlayerBody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * Speed, PlayerBody.velocity.y, 0);
            if (Speed < 6f)
            {
                Speed += 0.1f;
            }

        }
        else
        {
            if (Speed > 0.5f)
            {
                Speed -= 0.1f;
            }
        }

        if (PlayerBody.velocity.x == 0f)
        {
            Speed = 1;
        }

        if (PlayerBody.velocity.x < 0)
        {
            PlayerBody.velocity += new Vector3(0.1f, 0f, 0f);
            PlayerBody.angularVelocity += new Vector3(0.1f, 0f, 0f);

        }
        if (PlayerBody.velocity.x > 0)
        {
            PlayerBody.velocity -= new Vector3(0.1f, 0f, 0f);
            PlayerBody.angularVelocity -= new Vector3(0.1f, 0f, 0f);
        }

        if (PlayerBody.velocity.x > -0.5f && PlayerBody.velocity.x < 0.5f)
        {
            PlayerBody.velocity = new Vector3(0f, PlayerBody.velocity.y, 0f);
            PlayerBody.angularVelocity = new Vector3(0f, PlayerBody.velocity.y, 0f);
        }

        if (JumpOn == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                PlayerBody.AddForce(0f, JumpForce, 0f);
            }
        }
        if (Input.GetButton("Jump"))
        {

        }
        else
        {
            if (PlayerBody.velocity.y > 0)
            {
                PlayerBody.velocity -= new Vector3(0f, 1f, 0f);
                PlayerBody.angularVelocity -= new Vector3(0f, 1f, 0f);

            }

        }


        if (PlayerBody.velocity.x < -1)
        {
            Player.transform.eulerAngles = new Vector3 (0, 180, 0);
        }

        if (PlayerBody.velocity.x > 1)
        {
            Player.transform.eulerAngles = new Vector3(0, 0, 0);
        }



       
    }

    void JumpSwitch(bool JumpA)
    {
        JumpOn = JumpA;

    }


}
