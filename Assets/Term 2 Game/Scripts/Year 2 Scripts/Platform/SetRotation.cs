using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public Vector3 Angles;

    void Update()
    {

        transform.eulerAngles = Angles;
    }
}
