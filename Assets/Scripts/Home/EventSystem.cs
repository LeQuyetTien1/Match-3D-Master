using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class EventSystem : MonoBehaviour
{
    public Text goldText, heartText;
    public static int gold = 1000, heart = 3;
    public Image scoreBar;
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
}
