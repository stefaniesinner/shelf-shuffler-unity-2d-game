using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private AudioSource flippingBook;
    [SerializeField] private AudioSource backgroundSoundStart;

    public void StartGame()
    {

        SceneManager.LoadScene("SampleScene");
        flippingBook.Play();

        backgroundSoundStart.Play();

    }

    public void Help()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    public void QuitGame()
    {

        Debug.Log("Quitting Game...");
        Application.Quit();

    }

}