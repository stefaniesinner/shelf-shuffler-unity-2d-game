using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController obj;

    private bool gamePaused = false;
    private int score = 0;

    // Start is called before the first frame update
    private void Start()
    {
        obj = this;

        gamePaused = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void AddScore(int scoreGive)
    {
        score += scoreGive;
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
