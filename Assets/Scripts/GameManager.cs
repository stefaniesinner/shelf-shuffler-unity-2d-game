using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>GameManager</c> handles the game. It starts the application to let the user play the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public bool isPaused;

    private void Awake()
    {
        game = this;
    }

    private void Start()
    {
        isPaused = false;
    }

    private void OnDestroy()
    {
        game = null;
    }
}
