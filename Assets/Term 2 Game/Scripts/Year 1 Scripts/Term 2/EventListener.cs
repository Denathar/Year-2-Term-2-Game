using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventListener : MonoBehaviour
{
    Rigidbody myRidgidbody;

    private void Start()
    {
        myRidgidbody = GetComponent<Rigidbody>();
    }
    public void OnFowardEvent()
    {
        myRidgidbody.AddForce(200f, 0f, 0f);
    }

    public void OnJumpEvent()
    {
        //float random = Random.Range(100f, 500f);
        myRidgidbody.AddForce(0f, 200f, 0f);
    }

    public void OnDestroyEvent()
    {
        Destroy(gameObject);
    }
}

