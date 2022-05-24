using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static Text ScoreText;
    public static int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
    }

    public static void SetScore(int value)
    {
        ScoreText.text = value.ToString();
    }

    public static void IncrementScore(int value)
    {
        Score += value;
        ScoreText.text = "Attempts: " +  Score.ToString();
    }
}
