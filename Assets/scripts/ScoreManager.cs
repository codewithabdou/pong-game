using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;
    public Text player1ScoreText;
    public Text player2ScoreText;

    public void IncreasePlayer1Score()
    {
        player1Score++;
        if (player1Score == 5) SceneManager.LoadScene("MainMenu");
        player1ScoreText.text = player1Score.ToString();
    }

    public void IncreasePlayer2Score()
    {
        player2Score++;
        if (player2Score == 5) SceneManager.LoadScene("MainMenu");

        player2ScoreText.text = player2Score.ToString();

    }
}
