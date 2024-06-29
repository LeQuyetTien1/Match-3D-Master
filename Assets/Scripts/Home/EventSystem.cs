using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class EventSystem : MonoBehaviour
{
    public Text goldText, heartText;
    public static int gold = 2000, heart = 3;
    public static bool isInfinity = false;
    private void Update()
    {
        if (isInfinity)
        {
            HideHeartText();
        }
        else
        {
            ShowHeartText();
            heartText.text = heart.ToString();
        }
        goldText.text = gold.ToString();
    }
    public void HideHeartText()
    {
        heartText.enabled = false;
    }
    public void ShowHeartText()
    {
        heartText.enabled = true;
    }
    public void CheckNumberOfLife()
    {
        if(heart == 0)
        {
            ScoreBar.score = 0;

        }
    }
}
