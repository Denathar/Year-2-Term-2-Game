using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRigidbody : MonoBehaviour
{
    public Transform Object;
    public Transform ChildObject;
    private Rigidbody MyRB;

    // Start is called before the first frame update
    void Start()
    {
        
        MyRB = GetComponent<Rigidbody>();


        ChildObject = transform.GetChild(0);


    }

    // Update is called once per frame
    void Update()
    {



        //if (Object != null)
        //{
        //    transform.position = Object.position;
        //}

        if (transform.childCount == 0)
        {
            MyRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY
                | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            MyRB.velocity -= new Vector3(MyRB.velocity.x, 0, 0);

            MyRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

    }


}
