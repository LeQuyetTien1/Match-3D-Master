using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public int level;
    public ButtonEvent buttonEvent;
    public void LoadLevle()
    {
        if(EventSystem.heart > 0 || EventSystem.isInfinity ==true)
        {
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            buttonEvent.ShowMessage("Not enough life, please wait or buy more");
        }
    }
}
