using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollAvtivation : MonoBehaviour
{
    public Collider TelCollStart;
    public Collider TelCollEnd;

    private void OnTriggerEnter(Collider other)
    {
        TelCollStart.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        TelCollEnd.enabled = false;
    }
}
