using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>AudioManager</c> handles the audio of the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager aud;

    [SerializeField]
    private AudioSource jumpingAudio;

    private void Awake()
    {
        aud = this;
    }

    public void PlaySound(AudioSource src)
    {
        src.Play();
    }
    
    public AudioSource JumpingAudio
    {
        get { return jumpingAudio; }
    }

    private void OnDestroy()
    {
        aud = null;
    }
}
