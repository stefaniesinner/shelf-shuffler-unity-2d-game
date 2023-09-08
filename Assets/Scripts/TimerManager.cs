using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>TimerManager</c> handles the timer that runs during the game and ends the game when 
/// it expires.
/// </summary>
public class TimerManager : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;

            LoadGameOverScene();
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void LoadGameOverScene()
    {

        //SceneManager.LoadScene("EndScreen");
    }
}
