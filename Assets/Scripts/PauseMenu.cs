using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu; 

    public void Pause(){
        pauseMenu.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void Resume(){
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f; 

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home(int sceneID){
        Time.timeScale = 1f; 


    }

    public void Help(){

    }

    public void Quit(){
        SceneManager.LoadScene("StartMenu");
    }

}
