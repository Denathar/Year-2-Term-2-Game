using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public Transform Target;

    public float DegreesPerSec;

    private Rigidbody myRigidBody;


    void Start()
    {
        
        myRigidBody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //Target = GameObject.FindGameObjectWithTag(targetTag.ToString()).transform;

        if (Target != null)
        {
            Vector3 dirFromMeToTarget = Target.position - transform.position;

            //dirFromMeToTarget.y = 0.0f;

            Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);

            myRigidBody.MoveRotation(Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (DegreesPerSec / 360.0f)));

        }

        
    }

    void RadarInput(Transform Targetin)
    {
        Target = Targetin;

    }

}
