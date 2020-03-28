using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform muzzlePoint;
    public GameObject projectile;

    public string ActivationKey;

    public string DeactivationKey;

    public string DeactivationKey2;

    public string DeactivationKey3;

    public string DeactivationKey4;

    public bool Active;

    public float Length;

    public bool Jitter;

    float laserX;
    float laserY;
    float laserZ;

    private void Start()
    {
        laserX = transform.localScale.x;
        laserY = transform.localScale.y;
        laserZ = transform.localScale.z;
    }

    void Update()
    {
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
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                foreach (Transform child in muzzlePoint)
                {
                    Destroy(child.gameObject);
                }
            }
            if (Jitter == false)
            {
                muzzlePoint.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
        }


    }

    private void Fire()
    {
        GameObject newObject = Instantiate(projectile, muzzlePoint.transform.position, muzzlePoint.transform.rotation);

        newObject.transform.localScale = new Vector3(laserX, laserY, Length);

        newObject.transform.parent = muzzlePoint;

        
    }
}
