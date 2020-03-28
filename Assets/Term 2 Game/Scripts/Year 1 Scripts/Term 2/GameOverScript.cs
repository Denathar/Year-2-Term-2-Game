using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

    }
    private void Update()
    {
        if (Player == null)
        {

            SceneManager.LoadScene("Game");

        }
    }
 
}

