using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLunge : MonoBehaviour
{
    public TargetTag targetTag;

    public float lungSpeed;

    float timer = 0.5f;




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            SendMessageUpwards("lunge", lungSpeed);

            Debug.Log("Yeet");

            Invoke("lungStop", timer);

        }
    }

    void lungStop()
    {
        SendMessageUpwards("lungeEnd");
    }

}
