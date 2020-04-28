using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimationMovment : MonoBehaviour
{
    public AudioSource AudioRight;
    public AudioSource AudioLeft;


    public void PlayAudioRight()
    {
        AudioRight.Play();
    }
    public void PlayAudioLeft()
    {
        AudioLeft.Play();
    }
}
