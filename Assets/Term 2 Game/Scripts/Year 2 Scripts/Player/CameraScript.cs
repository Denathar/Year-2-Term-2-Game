using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    private Transform target;
    public Vector3 Offset;


    // Start is called before the first frame update
    void Start()
    {
        target = Player.transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player != null)
        {
            //transform.LookAt(target);
            transform.position = Player.transform.position + Offset;
        }

    }

}
