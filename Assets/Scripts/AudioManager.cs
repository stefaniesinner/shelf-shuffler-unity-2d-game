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
    private AudioClip walkingSound;
    [SerializeField]
    private AudioClip jumpingSound;

    private AudioSource audSrc;

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
        audSrc.PlayOneShot(clip);
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
