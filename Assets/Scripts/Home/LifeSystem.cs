using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading.Tasks;

public class LifeSystem : MonoBehaviour
{
    public int recoverTime, infinityTime;
    public static int tempTime;
    public static float time = 10;
    public int maxLife;
    public Text recoverText;
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        Recover();
    }
    private void Recover()
    {
        if (EventSystem.isInfinity)
        {
            CountTime();
            time -= Time.deltaTime;
            if(time < 0)
            {
                time = tempTime;
                EventSystem.isInfinity = false;
                tempTime = 0;
            }
            return;
        }
        if (EventSystem.heart < maxLife)
        {
            CountTime();
            time -= Time.deltaTime;
            if (time < 0)
            {
                IncreaseLife();
            }
        }
        else
        {
            recoverText.text = "Full";
            tempTime = (int)time;
        }
    }
    private void CountTime()
    {
        int minute = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);
        recoverText.text = minute + ":" + (second < 10 ? "0" + second : second);
    }
    private void IncreaseLife()
    {
        Debug.Log("Increase Life");
        time = recoverTime;
        EventSystem.heart++;
        CountTime();
    }
    public void CountInfinityTimeRemain()
    {        
        if (EventSystem.isInfinity == true)
        {
            tempTime = (int)time;
            time = infinityTime;
        }       
    }
}
