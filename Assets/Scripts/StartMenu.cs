using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
   
    public void StartGame(){

        SceneManager.LoadScene("SampleScene");

    }

    public void Help(){
        SceneManager.LoadScene("HelpMenu");
    }

    public void QuitGame(){

        Debug.Log("Quitting Game...");
        Application.Quit();

    }

}
