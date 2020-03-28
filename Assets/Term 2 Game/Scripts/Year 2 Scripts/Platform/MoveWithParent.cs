using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithParent : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.SetParent(transform);

    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
