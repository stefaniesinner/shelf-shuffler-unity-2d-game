using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager aud;

    [SerializeField]
    private AudioClip jumpSound;

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

    public AudioClip JumpSound
    {
        get { return jumpSound; }
    }

    private void OnDestroy()
    {
        aud = null;
    }
}
