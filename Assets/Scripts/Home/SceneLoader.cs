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
    public void LoadLevle()
    {
        SceneManager.LoadScene("Level" + level);
    }
}
