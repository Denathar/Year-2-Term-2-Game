using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject Player;
    public GameObject VictoryScreen;
    public TargetTag targetTag;
    bool GUIOFF = false;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            Player.GetComponent<PlayerMovmentNew>().enabled = false;
            VictoryScreen.SetActive(true);


        }
    }
}
