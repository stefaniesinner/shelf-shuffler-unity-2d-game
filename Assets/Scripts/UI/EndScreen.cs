using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public void PlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

}