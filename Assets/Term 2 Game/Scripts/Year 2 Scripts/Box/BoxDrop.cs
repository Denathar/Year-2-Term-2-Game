using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrop : MonoBehaviour
{
    public GameObject PickUpCollider;
    public Collider hit;
    public TargetTag targetTag;
    public TargetTag targetTag2;
    public TargetTag targetTag3;
    public TargetTag targetTag4;

    public GameObject player;
    public bool jump;

    private void Update()
    {
        jump = player.GetComponent<PlayerMovmentNew>().JumpOn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            hit = other;
            PickUpCollider.SendMessage("Drop");
            Debug.Log("drop");
        }
        
        if (player.GetComponent<PlayerMovmentNew>().JumpOn == false)
        {
            if (other.gameObject.tag == targetTag2.ToString() || other.gameObject.tag == targetTag3.ToString() || other.gameObject.tag == targetTag4.ToString())
            {
                hit = other;
                PickUpCollider.SendMessage("Drop");
                Debug.Log("drop");
            }
        }

        //player.GetComponent<PlayerMovmentNew>();

    }

  


}
