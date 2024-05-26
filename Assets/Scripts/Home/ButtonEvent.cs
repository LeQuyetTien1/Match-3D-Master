using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public GameObject[] Panel;
    public Image[] backGround;
    private Color brown = new Color(0.8584906f, 0.4253691f, 0.1174351f, 1);
    public void GoShop()
    {
        SetPanel(1);
    }
    public void GoLevel()
    {
        SetPanel(2);
    }
    public void GoLeaderBoard()
    {
        SetPanel(3);
    }
    public void GoSetting()
    {
        SetPanel(4);
    }
    private void SetPanel(int id)
    {
        for(int i = 0; i<Panel.Length; i++)
        {
            if(i == id - 1)
            {
                Panel[i].SetActive(true);
                backGround[i].color = Color.yellow;
            }
            else
            {
                Panel[i].SetActive(false);
                backGround[i].color = brown;
            }
        }
    }
}
