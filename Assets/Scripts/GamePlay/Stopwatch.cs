using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Stopwatch : MonoBehaviour
{
    public int limitTime;
    public float gameTime;
    public Text timeText;
    public UnityEvent gameOver;
    public bool isStop = false;
    public static int recoverTime;

    private void Start()
    {
        gameTime = limitTime;
    }
    private void CountTime()
    {
        int minute = Mathf.FloorToInt(gameTime / 60);
        int second = Mathf.FloorToInt(gameTime % 60);

        timeText.text = minute + ":" + (second < 10 ? "0" + second : second);
    }
    private void Update()
    {
        CountTime();
        LifeSystem.time -= Time.deltaTime;
        if ((int)LifeSystem.time == 0)
        {
            LifeSystem.time = recoverTime;
            if(EventSystem.heart < 10) EventSystem.heart++;
        }
        if ((int)gameTime > 0 && isStop == false)
        {
            gameTime -= Time.deltaTime;
        }
        else if((int)gameTime == 0)
        {
            gameOver.Invoke();
            
        }
        if ((int)gameTime <= 10 && isStop != true)
        {
            timeText.color = Color.red ;
        }
    }
}
