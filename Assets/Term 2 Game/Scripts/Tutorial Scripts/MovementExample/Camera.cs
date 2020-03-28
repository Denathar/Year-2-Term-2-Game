using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform cameraTarget = null;
    public Vector3 followDamp = new Vector3(25.0F, 25.0F, 0.0F);

    private float currentVelocityX = 0;
    private float currentVelocityY = 0;
    private float currentVelocityZ = 0;

    void LateUpdate()
    {
        Vector3 position = transform.position;        
        if(followDamp.x > 0.0F)
        {
            position.x = Mathf.SmoothDamp(position.x, cameraTarget.transform.position.x, ref currentVelocityX, followDamp.x * Time.deltaTime);
        }
        if (followDamp.y > 0.0F)
        {
            position.y = Mathf.SmoothDamp(position.y, cameraTarget.transform.position.y, ref currentVelocityY, followDamp.y * Time.deltaTime);
        }
        if (followDamp.z > 0.0F)
        {
            position.z = Mathf.SmoothDamp(position.z, cameraTarget.transform.position.z, ref currentVelocityZ, followDamp.z * Time.deltaTime);
        }
        transform.position = position;
    }
}