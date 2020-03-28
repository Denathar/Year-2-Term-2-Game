using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
