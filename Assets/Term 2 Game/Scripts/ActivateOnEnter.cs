using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class ActivateOnEnter : MonoBehaviour
{
    public bool On_Or_Off;

    public GameObject Object;

    public void Start()
    {
        Object.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Object.SetActive(On_Or_Off);
    }
}
