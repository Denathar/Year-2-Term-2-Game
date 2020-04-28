using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAudioAnim : MonoBehaviour
{
    public AudioSource SwordAudio;
    public AudioSource SwordAudio2;
    public AudioSource SwordAudio3;
    public AudioSource SwordAudio4;


    public void PlayAudio1()
    {
        SwordAudio.Play();
    }
    public void PlayAudio2()
    {
        SwordAudio2.Play();
    }
    public void PlayAudio3()
    {
        SwordAudio3.Play();
    }
    public void PlayAudio4()
    {
        SwordAudio4.Play();
    }
}
