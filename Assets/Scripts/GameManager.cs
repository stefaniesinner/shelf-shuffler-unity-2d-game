using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script that handles the game.
 */
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
