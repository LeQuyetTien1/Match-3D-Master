using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource gamePlaySound;
    public void PlayClickAudio()
    {
        clickSound.Play();
    }
    public void PlayGameSound()
    {
        gamePlaySound.Play();
    }
    public void PauseGameSound()
    {
        gamePlaySound.Pause();
    }
}
