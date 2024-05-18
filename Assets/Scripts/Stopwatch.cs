using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Stopwatch : MonoBehaviour
{
    public int limitTime;
    private float gameTime;
    public Text timeText;
    public UnityEvent gameOver;
    public bool isStop = false;

    private void Start()
    {
        gameTime = limitTime;
    }
    private void CountTime()
    {
        int minute = Mathf.FloorToInt(gameTime / 60);
        int second = Mathf.FloorToInt(gameTime % 60);

        /*TimeSpan a = new TimeSpan((int)gameTime);
        int minute = a.Minutes;
        int second = a.Seconds;*/
        timeText.text = minute + ":" + (second < 10 ? "0" + second : second);
    }
    private void Update()
    {
        CountTime();
        
        if ((int)gameTime > 0 && isStop == false)
        {
            gameTime -= Time.deltaTime;
        }
        if((int)gameTime == 0)
        {
            gameOver.Invoke();
        }
    }
}
