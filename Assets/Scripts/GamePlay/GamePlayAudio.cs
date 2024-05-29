using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    public AudioSource gamePlaySound;
    public AudioSource clickSound;
    void Start()
    {
        gamePlaySound.Play();
    }
    public void PlayClickAudio()
    {
        clickSound.Play();
    }
}
