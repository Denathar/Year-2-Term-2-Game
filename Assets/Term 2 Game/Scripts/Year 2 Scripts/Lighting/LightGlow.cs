using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGlow : MonoBehaviour
{
    public Light GlowLight;

    public float Amount;
    public float targetExtend = 5;
    public float targetRetract = 1;

    private void Start()
    {
        GlowLight = GetComponent<Light>();
        GlowLight.intensity = targetRetract;
    }
    void Update()
    {
        GlowLight.intensity = GlowLight.intensity + Amount * Time.deltaTime;
        if (GlowLight.intensity >= targetExtend)
        {
            Amount = -Amount;
        }
        if (GlowLight.intensity <= targetRetract)
        {
            Amount = ++Amount;
            
        }
    }
}
