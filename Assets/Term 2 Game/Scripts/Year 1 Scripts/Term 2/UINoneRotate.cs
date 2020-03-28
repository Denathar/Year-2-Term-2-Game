using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINoneRotate : MonoBehaviour


   
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(60, 0, 0);
    }
}
