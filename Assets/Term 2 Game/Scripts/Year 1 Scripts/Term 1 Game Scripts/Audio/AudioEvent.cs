using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    public AudioSource[] TurnOffEffect;
    int position = 0;

    public float timer = 0.3f;
	
    private void OnTriggerEnter(Collider other)
    {
        InvokeRepeating("Effects", timer, timer);
        //Invoke("TurnOffLight", timer); one time
    }

    void Effects()
    {
        if (TurnOffEffect.Length > position)
        {
            if (TurnOffEffect[position] != null)
            {
                TurnOffEffect[position].Play();
                position++;
            }
        }

        if(position > TurnOffEffect.Length)
        {
            CancelInvoke();
        }
    
    }
}
