using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour
{
    public Text goldText, heartText;
    public static int gold = 300, heart = 3;
    public Image scoreBar;
    private void Update()
    {
        goldText.text = gold.ToString();
        heartText.text = heart.ToString();
    }
}
