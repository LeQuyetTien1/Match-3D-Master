using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource gamePlaySound;
    public List<AudioSource> sounds, musics;
    private void Update()
    {
        foreach(var music in musics)
        {
            music.volume = HomeAudio.musicVolume;
        }
        foreach( var sound in sounds)
        {
            sound.volume = HomeAudio.soundVolume;
        }
    }
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
