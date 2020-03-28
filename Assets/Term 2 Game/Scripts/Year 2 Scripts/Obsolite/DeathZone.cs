using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Color colour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {

        #region Draw Cube

        Gizmos.color = colour;
        Gizmos.DrawCube(transform.position, transform.localScale);

        #endregion

        Gizmos.color = Color.green;

        Gizmos.DrawSphere(transform.position, 3);

    }
}
