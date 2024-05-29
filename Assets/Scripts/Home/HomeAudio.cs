using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAudio : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource homePlaySound;
    private void Start()
    {
        homePlaySound.Play();
    }
    public void PlayClickAudio()
    {
        clickSound.Play();
    }
}
