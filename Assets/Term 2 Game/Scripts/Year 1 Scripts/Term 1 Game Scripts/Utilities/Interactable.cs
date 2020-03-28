using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    HUD hud;
    public string message;

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hud != null)
        hud.SetToolTip(message);
    }

    private void OnTriggerExit(Collider other)
    {
        if (hud != null)
        hud.ClearToolTip();
    }

    private void OnDestroy()
    {
        if (hud != null)
       
        hud.ClearToolTip();

    }
    
}
