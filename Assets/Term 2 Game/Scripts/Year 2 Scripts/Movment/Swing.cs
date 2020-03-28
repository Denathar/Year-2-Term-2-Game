using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    float current;
    
    public float Speed = 2f;
    public float angle;

    // Update is called once per frame
    void FixedUpdate()
    {

        


        if (current >= angle)
        { 
            Speed = -Speed;
        }

        if (current <= -angle)
        {
            Speed = -Speed;
        }

        transform.eulerAngles = new Vector3(0, 0, current);

        current = current + Speed * Time.deltaTime;
    }
}
