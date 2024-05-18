using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int level;
    public void LoadScene()
    {
        SceneManager.LoadScene("level" + level);
    }
}
