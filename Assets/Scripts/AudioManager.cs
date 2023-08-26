using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager aud;

    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip hitSound;

    private AudioSource audioSrc;

    private void Awake()
    {
        aud = this;
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }

    public void PlayJumpSound()
    {
        PlaySound(jumpSound);
    }

    public void PlayHitSound()
    {
        PlaySound(hitSound);
    }

    private void OnDestroy()
    {
        aud = null;
        audioSrc = null;
    }
}
