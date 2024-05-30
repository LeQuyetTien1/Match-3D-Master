using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HomeAudio : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource homePlaySound;
    private void Start()
    {
        /*homePlaySound.Play();*/
    }
    private void Update()
    {
        Debug.Log(homePlaySound.isPlaying);
    }
    public void PlayClickAudio()
    {
        Debug.Log("Play Click Audio");
        clickSound.Play();
        Debug.Log(clickSound.isPlaying);
    }
    [ContextMenu("Play Game Opening")]
    public void PlayGameOpening()
    {
        homePlaySound.Play();
    }
    [ContextMenu("Stop Game Opening")]
    public void StopGameOpening()
    {
        homePlaySound.Stop();
    }
}
