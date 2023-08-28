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
    private AudioSource walkingSound;
    [SerializeField]
    private AudioSource jumpingSound;

    private void Awake()
    {
        aud = this;
    }

    /// <summary>
    /// Play the respective audio clip.
    /// </summary>
    /// <param name="src">Audio source which plays the respective audio clip.</param>
    public void PlayAudio(AudioSource src)
    {
        src.Play();
    }
    
    public AudioSource WalkingSound
    {
        get { return walkingSound; }
    }

    public AudioSource JumpingSound
    {
        get { return jumpingSound; }
    }

    private void OnDestroy()
    {
        aud = null;
    }
}
