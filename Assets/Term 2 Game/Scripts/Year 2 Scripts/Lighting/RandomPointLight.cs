using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointLight : MonoBehaviour
{
    public Light Light;

    private float startRange;
    private float targetRange;

    public float MaxRange;
    public float MinRange;

    public float AnimTime = 1.0F;
    private float currentAnimTime = 0.0F;

    private void Start()
    {
        startRange = Light.intensity;
        targetRange = Random.Range(MinRange, MaxRange);
    }

    private void Update()
    {
        currentAnimTime += Time.deltaTime;
        //Any variable declared within code only exists within the curley braces it is declared within
        float animPercent = currentAnimTime / AnimTime;
        Light.intensity = Mathf.Lerp(startRange, targetRange, animPercent);
        if(currentAnimTime >= AnimTime)
        {
            startRange = targetRange;
            targetRange = Random.Range(MinRange, MaxRange);
            currentAnimTime = 0.0F;
        }
    }
}
