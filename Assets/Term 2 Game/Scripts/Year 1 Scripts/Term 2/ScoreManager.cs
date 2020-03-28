using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score;

    public Text ScoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
        //Score = 100;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = Score.ToString();
    }

    public void AddToScore(int amount)
    {
        Score += amount;
    }

    public void ResetScore()
    {
        Score = 000;
    }
}
