using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class FreezeButton : MonoBehaviour
{
    public Text timeText, freezeCountText;
    public int limitTime;
    private float time;
    public static int freezeCount = 1;
    public GameObject clockImage, freezeTime, freezeBackground;
    public Stopwatch stopwatch;
    public AudioSource freezeSound;
    private void Start()
    {
        time = limitTime;
    }
    private void CountTime()
    {
        timeText.text = (int)time + "s";
    }
    private void Update()
    {
        CountTime();
        freezeCountText.text = freezeCount.ToString();

        if (time > 0 && stopwatch.isStop == true)
        {
            time -= Time.deltaTime;
        }
        else
        {
            clockImage.SetActive(true);
            freezeTime.SetActive(false);
            freezeBackground.SetActive(false);
            stopwatch.isStop = false;
            stopwatch.timeText.color = Color.white;
        }
    }
    public void Freeze()
    {
        if (freezeCount > 0)
        {
            PlayFreezeSound();
            time = 10;
            clockImage.SetActive(false);
            freezeTime.SetActive(true);
            freezeBackground.SetActive(true);
            stopwatch.isStop = true;
            stopwatch.timeText.color = Color.cyan;
            freezeCount--;
        }       
    }
    private void PlayFreezeSound()
    {
        freezeSound.Play();
    }
}
