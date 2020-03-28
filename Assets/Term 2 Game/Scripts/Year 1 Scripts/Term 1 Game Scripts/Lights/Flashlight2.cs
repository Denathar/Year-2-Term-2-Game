using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight2 : MonoBehaviour {

    bool ison = false;

    float batteryPercentage = 100f;

    public float batteryDrainAmount = 3.0f;

    public float batteryDrainTimer = .5f;

    public Light flashlight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("f"))
        {
            Toggle();
        }
        flashlight.enabled = ison;
	}
    void Toggle()
    {
        ison = !ison;

        if (ison)
        {
            StartDrainingBattery();
        }
        else
        {
            StopDrainingBattery();
        }
    }
    private void DrainBattery()
    {
        Debug.Log(batteryDrainAmount + "%Battery is left");
        // Check if we have enough power
        if(batteryPercentage - batteryDrainAmount > 0f)
        {
            batteryPercentage -= batteryDrainAmount;
        }
        else
        {
            batteryPercentage = 0f;
            Toggle();
        }
    }
    private void StartDrainingBattery()
    {
        InvokeRepeating("DrainBattery", 0f, batteryDrainTimer);
    }
    private void StopDrainingBattery()
    {
        CancelInvoke();
    }
    public float CheckBatteryAmount()
    {
        return batteryPercentage / 100.0f;
    }

    public void ResetBattery()
    {
        batteryPercentage = 100f;
    }
}
