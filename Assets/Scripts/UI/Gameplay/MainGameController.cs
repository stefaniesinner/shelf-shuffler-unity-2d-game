using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script that handles the gameplay.
 */
public class MainGameController : MonoBehaviour
{
    public static MainGameController obj;

    public bool gamePaused = false;
    public int score = 0;

    public int maxStorage = 3;

    private void Awake()
    {
        obj = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        gamePaused = false;
        UIManager.manager.StartGame();
    }

    public void AddScore(int scoreGive)
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
