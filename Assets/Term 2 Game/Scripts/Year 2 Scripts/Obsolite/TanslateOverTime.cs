using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanslateOverTime : MonoBehaviour
{
    public float Target = 0;
    //public float current = 0;

    public float MovePosition = 0;
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        Vector3 targetPosition = new Vector3(MovePosition, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (MovePosition == Target)
        {
            Target = -Target;
        }
    }
}
