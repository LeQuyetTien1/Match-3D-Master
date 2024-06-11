using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text rank1Text, rank2Text, rank3Text;
    public static int rank1Score, rank2Score, rank3Score;
    public static int [] scores = new int[3] /*{rank1Score, rank2Score, rank3Score}*/;
    public static int currentScore;
    /*private void Start()
    {
        CheckRank();
    }*/
    private void Update()
    {
        rank1Text.text = scores[0].ToString()/*rank1Score.ToString()*/;
        rank2Text.text = scores[1].ToString()/*rank2Score.ToString()*/;
        rank3Text.text = scores[2].ToString()/*rank3Score.ToString()*/;
    }
    public static void CheckRank()
    {
        for(int i=0; i < scores.Length; i++)
        {
            if (scores[i] < currentScore)
            {
                for(int j = scores.Length - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                }
                scores[i] = currentScore;
                break;
            }
        }
        Debug.Log(LeaderBoard.currentScore);
    }
}
