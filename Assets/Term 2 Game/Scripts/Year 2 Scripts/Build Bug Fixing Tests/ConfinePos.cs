using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfinePos : MonoBehaviour
{
    private float OriginalPosX;
    private float OriginalPosY;
    private float OriginalPosZ;
    public bool xConfine = false;
    public bool yConfine = false;
    public bool zConfine = false;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosX = gameObject.transform.position.x;
        OriginalPosY = gameObject.transform.position.y;
        OriginalPosZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (xConfine == true)
        {
            gameObject.transform.position = new Vector3(OriginalPosX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (yConfine == true)
        {
            gameObject.transform.position = new Vector3(OriginalPosY, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (zConfine == true)
        {
            gameObject.transform.position = new Vector3(OriginalPosZ, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        
        

    }
}
