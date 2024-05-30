using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HomeAudio : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource homePlaySound;
    public void PlayClickAudio()
    {
        Debug.Log("Play Click Audio");
        clickSound.Play();
        Debug.Log(clickSound.isPlaying);
    }
}
