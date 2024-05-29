using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public static int score = 0, minScore = 0, maxScore = 10;
    public int rewardGold;
    private float tempScore;
    public Image scoreBar;
    private float speed;
    public Text scoreText, rewardGoldText;
    private void Start()
    {
        tempScore = score;
        score += YellowBar.score;
    }
    private void Update()
    {
        CountSpeed();
        if (tempScore < score)
        {
            tempScore += Time.deltaTime * speed;
        }
        scoreBar.fillAmount = (tempScore - minScore)/ (maxScore - minScore);
        scoreText.text = (int)tempScore + "/" + maxScore;
        rewardGoldText.text = rewardGold.ToString();
        if ((int)tempScore == maxScore)
        {
            minScore = maxScore;
            maxScore *= 2;
            EventSystem.gold += rewardGold;
            rewardGold *= 2;
        }
    }
    private void CountSpeed()
    {
        speed = YellowBar.score / 3;
    }
}
