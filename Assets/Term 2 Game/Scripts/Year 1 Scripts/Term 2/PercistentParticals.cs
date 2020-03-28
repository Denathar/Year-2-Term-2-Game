using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercistentParticals : MonoBehaviour
{
    public float timer = 1f;



    void Particals()
    {
        GetComponent<ParticleSystem>().Stop();
        transform.parent = null;
        Invoke("DestroyParticals", timer);
        transform.localScale = new Vector3(1, 1, 1);
    }
    void DestroyParticals()
    {


        Destroy(gameObject);
    }

}
