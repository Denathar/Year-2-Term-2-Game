using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public Text Slowed;

    public Slider StaminaBar;
    public int Stamina;
    public int CurrentStamina;

    public int StaminaUseAmount;
    public float UseTime = 1.0f;
    public float UseTimer = 0.0f;

    public int StaminaRegen;
    public float RegenTime = 1.0f;
    float RegenTimer = 0.0f;


    private Vector3 velocity;
    public float speed = 6.0f;
    public float RunSpeed = 8.0f;

    public float Originalspeed;

    private Rigidbody myRidgidBody;
    private Transform cannon;

    private int floorMask;
    private float cameraRayLength = 50f;

    bool isSlowed;
    public float SlowDuration;

    public TargetTag targetTag;

    // Start is called before the first frame update
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");

        myRidgidBody = GetComponent<Rigidbody>();
        cannon = transform.Find("Cube");

        Originalspeed = speed;

        CurrentStamina = Stamina;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);

        //Turn();

        if (isSlowed == true)
        {
            Slowed.enabled = true;

            runStop();
        }
        if (isSlowed == false)
        {
            Slowed.enabled = false;

            if (Input.GetButton("Run"))
            {
                Run();

                if (velocity != Vector3.zero)
                {
                    if (UseTimer >= UseTime)
                    {
                        UseTimer -= UseTime;

                        UseStamina(StaminaUseAmount);
                    }
                    UseTimer += Time.deltaTime;
                }

            }
        }

        if (Input.GetButton("Run") == false)
        {
            runStop();
        }

        StaminaBar.value = (float)CurrentStamina / (float)Stamina;

        if (CurrentStamina <= 0)
        {
            runStop();
        }

        if (CurrentStamina >= Stamina)
        {
            CurrentStamina = Stamina;
        }
        if (CurrentStamina <= 0)
        {
            StopUseStamina();
        }

        if (RegenTimer >= RegenTime)
        {
            RegenTimer -= RegenTime;

            RegenStamina();
        }
        RegenTimer += Time.deltaTime;

        if (CurrentStamina >= Stamina)
        {
            StopStaminaRegen();
        }


    }

    void Run()
    {
        speed = RunSpeed;
        
    }

    void runStop()
    {
        speed = Originalspeed;
    }

    void UseStaminaMove(int StaminaUseAmount)
    {
        if (velocity != Vector3.zero)
        {
            CurrentStamina -= StaminaUseAmount;
            RegenTimer = 0;
        }

    }
    void UseStamina(int StaminaUseAmount)
    {
        CurrentStamina -= StaminaUseAmount;
        RegenTimer = 0;
    }
    void StopUseStamina()
    {
        UseTimer = 0;
    }

    void RegenStamina()
    {
        CurrentStamina += StaminaRegen;
    }

    void StopStaminaRegen()
    {
        RegenTimer = 0;
    }



    private void Move(float horizontal, float vertical)
    {
        velocity.Set(horizontal, 0.0f, vertical);

        velocity = velocity.normalized * speed * Time.deltaTime;

        myRidgidBody.MovePosition(myRidgidBody.position + velocity);
    }

    //private void Turn()
    //{
    //    Ray cameraRayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    RaycastHit floorHit;

    //    if(Physics.Raycast (cameraRayCast, out floorHit, cameraRayLength, floorMask))
    //    {
    //        Vector3 playerToMouse = floorHit.point - myRidgidBody.position;

    //        playerToMouse.y = 0.0f;

    //        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

    //        myRidgidBody.MoveRotation(newRotation);

    //        Vector3 cannonLookat = floorHit.point;

    //        cannonLookat.y += 1f;

    //        cannon.LookAt(cannonLookat);
    //    }
    //}
    public void Jump()
    {
        myRidgidBody.AddForce(0f, 5000f, 0f);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }
    void Update()
    {


        if (isSlowed == true)
        {

            SlowDuration -= Time.deltaTime;
            if (SlowDuration < 0)
            {
                SlowEffectStop();
            }
        }
    }
    void SlowEffectDuration(int SlowDurationIn)
    {
        SlowDuration = SlowDurationIn;
    }
    void SlowEffect(int amount)
    {
        if (speed > 0)
        {
            speed = amount;
            isSlowed = true;
        }
    }
    void SlowEffectStop()
    {
        speed = Originalspeed;
        isSlowed = false;
    }
}
