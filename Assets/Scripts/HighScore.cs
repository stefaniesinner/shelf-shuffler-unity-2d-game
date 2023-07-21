using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HighScore : MonoBehaviour
{

    public static HighScore instance;

    public TMP_Text playerScoreText;
    public TMP_Text highscoreText;

    int playerScore = 0;
    int highscore = 0;

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        highscore= PlayerPrefs.GetInt("highscore", 0);
        playerScoreText.text = playerScore.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE " + highscore.ToString();
    }

    public void AddPoint() {
        playerScore +=1;
        playerScoreText.text = playerScore.ToString() + " POINTS";
        if (highscore < playerScore){
            PlayerPrefs.SetInt("highscore", playerScore);
        }
    }

    
}