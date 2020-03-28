using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Image batteryImage;
    public Flashlight2 playerLight;
    public Text toolTipTextField;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        batteryImage.fillAmount = playerLight.CheckBatteryAmount();
	}

    public void SetToolTip(string message)
    {
        toolTipTextField.text = message;
    }

    public void ClearToolTip()
    {
        toolTipTextField.text = "";
    }


}
