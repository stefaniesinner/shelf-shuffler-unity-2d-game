using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>AudioManager</c> handles the audio of the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager aud;

    private void Awake()
    {
        aud = this;
    }

    private void OnDestroy()
    {
        aud = null;
    }
}
