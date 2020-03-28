using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform muzzlePoint;
    public GameObject projectile;

    public int ManaUsage;

    [Range(0f, 300f)]
    public float projectilesPerSecond;

    public float OriginalprojectilesPerSecond;


    private float projectileDelay;
    private float projectileTimer;


    public string ActivationKey;

    public string DeactivationKey;

    public string DeactivationKey2;

    public string DeactivationKey3;

    public string DeactivationKey4;

    public bool Active;

    public bool SingleClick;

    public bool HoldClick;

    public bool Jitter;

    public float Amount;
    float NAmount;

    void Start()
    {


        NAmount = -Amount;

        OriginalprojectilesPerSecond = projectilesPerSecond;

        //projectileDelay = 1.0f / projectilesPerSecond;

    }

    void Update()
    {

        projectileDelay = 1.0f / projectilesPerSecond;

        if (Input.GetButton(ActivationKey))
        {
            Active = true;
        }
        if (Input.GetButton(DeactivationKey))
        {
            Active = false;
        }
        if (Input.GetButton(DeactivationKey2))
        {
            Active = false;
        }
        if (Input.GetButton(DeactivationKey3))
        {
            Active = false;
        }
        if (Input.GetButton(DeactivationKey4))
        {
            Active = false;
        }

        if (Active == true)
        {
            if (SingleClick == true)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Fire();
                }
            }
            if (HoldClick == true)
            {
                if (Input.GetButton("Fire1"))
                {
                    Fire();
                }
            }

            else if (projectileTimer > 0)
            {
                projectileTimer = Mathf.Clamp(projectileTimer - Time.deltaTime, 0.0f, projectileDelay);
            }
            if (Jitter == false)
            {
                muzzlePoint.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
        }




    }

    private void Fire()
    {
        projectileTimer -= Time.deltaTime;
        while (projectileTimer <= 0)
        {
            Instantiate(projectile, muzzlePoint.transform.position, muzzlePoint.transform.rotation);

            projectileTimer += projectileDelay;

            BroadcastMessage("UseMana", ManaUsage);

            //muzzlePoint.transform.Rotate(0.0f, Random.Range(-5.0f, 5.0f), 0.0f);

            if (Jitter == true)
            {
                muzzlePoint.transform.localEulerAngles = new Vector3(Random.Range(NAmount, Amount), Random.Range(NAmount, Amount), 0f);
            }
            

        }
        
    }

    void NoMana()
    {
        projectilesPerSecond = 1f;


    }
    void HasMana()
    {

        projectilesPerSecond = OriginalprojectilesPerSecond;

    }
}
