using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HomeAudio : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource homePlaySound;
    public AudioSource buySound;
    public Slider musicSlider, soundSlider;
    public Text musicVolumeText, soundVolumeText;
    public static float musicVolume = 1, soundVolume = 1;
    public void PlayClickAudio()
    {
        clickSound.Play();
    }
    private void Start()
    {
        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
    }
    private void Update()
    {
        clickSound.volume = soundSlider.value;
        homePlaySound.volume = musicSlider.value;
        buySound.volume = soundSlider.value;
        musicVolume = musicSlider.value;
        soundVolume = soundSlider.value;
        musicVolumeText.text = ((int)(musicSlider.value * 100)).ToString();
        soundVolumeText.text = ((int)(soundSlider.value * 100)).ToString();
    }
}
