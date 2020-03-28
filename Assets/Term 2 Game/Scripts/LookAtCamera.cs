using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.Find("CM FreeLook1").transform;
    }
    void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
