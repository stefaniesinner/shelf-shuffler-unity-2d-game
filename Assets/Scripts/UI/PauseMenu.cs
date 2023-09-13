using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject helpMenu;

    [SerializeField] private AudioSource menuSound;
    [SerializeField] private AudioSource buttonSound;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        helpMenu.SetActive(false);
        menuSound.Play();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        buttonSound.Play();

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        buttonSound.Play();
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        buttonSound.Play();
    }

    public void Help()
    {
        helpMenu.SetActive(true);
        buttonSound.Play();

    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
        buttonSound.Play();
    }

}
