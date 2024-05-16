using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public TMP_Text scoreTextPlayer1;
    public TMP_Text scoreTextPlayer2;

    public int goalToWin;

    // Update is called once per frame
    private void Update()
    {
        if (scorePlayer1 >= goalToWin || scorePlayer2 >= goalToWin)
        {
            Debug.Log("Game Won");
        }
    }

    private void FixedUpdate()
    {
        scoreTextPlayer1.text = scorePlayer1.ToString();
        scoreTextPlayer2.text = scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        scorePlayer1++;
    }

    public void GoalPlayer2()
    {
        scorePlayer2++;
    }
}
