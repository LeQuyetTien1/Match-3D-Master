using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeFreeze : MonoBehaviour
{
    public Text timeText, freezeCountText;
    public int limitTime;
    private float time;
    public int freezeCount;
    public GameObject clockImage, freezeTime, freezeBackground;
    public Stopwatch stopwatch;
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
        }
    }
    public void Freeze()
    {
        if (freezeCount > 0)
        {
            time = 10;
            clockImage.SetActive(false);
            freezeTime.SetActive(true);
            freezeBackground.SetActive(true);
            stopwatch.isStop = true;
            freezeCount--;
        }       
    }
}
