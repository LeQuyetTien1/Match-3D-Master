using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class YellowBar : MonoBehaviour
{
    public Image yellowBar;
    private int scoreReward = 1;
    public static int score = 0;
    public Text barText, scoreText;
    public bool isRun = false;
    public float runTime, remainTime;
    void Start()
    {
        yellowBar.fillAmount = 0;
        barText.text = scoreReward.ToString();
        remainTime = runTime;
        score = 0;
    }

    void Update()
    {
        if (isRun)
        {
            remainTime -= Time.deltaTime;
            yellowBar.fillAmount = remainTime / runTime;
            if (remainTime <= 0)
            {
                runTime = 10;
                remainTime = runTime;
                isRun = false;
                scoreReward = 1;
                return;
            }
        }
        scoreText.text = score.ToString();
        barText.text = "x" + scoreReward.ToString();
    }
    public void IncreaseScore()
    {
        if (isRun)
        {
            runTime *= 0.8f;
            remainTime = runTime;
        }
        else
        {
            isRun = true;
        }       
        score += scoreReward;
        scoreReward++;
    }
}
