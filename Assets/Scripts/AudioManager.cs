using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>AudioManager</c> handles the audio of the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager aud;

    public AudioClip walkingSound;
    public AudioClip jumpingSound;

    public AudioSource audSrc;

    public float volume;

    private void Awake()
    {
        aud = this;
    }

    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play the respective audio clip.
    /// </summary>
    /// <param name="clip">The respective audio clip to be played.</param>
    public void PlaySound(AudioClip clip)
    {
        audSrc.PlayOneShot(clip, volume);
    }

    public AudioClip WalkingSound
    {
        get { return walkingSound; }
    }

    public AudioClip JumpingSound
    {
        get { return jumpingSound; }
    }

    private void OnDestroy()
    {
        aud = null;
    }
}
