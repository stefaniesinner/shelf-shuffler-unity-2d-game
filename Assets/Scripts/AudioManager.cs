using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager aud;

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

    public void PlaySound(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }

    private void PlayJumpSound()
    {
        PlaySound(jumpSound);
    }

    private void PlayHitSound()
    {
        PlaySound(hitSound);
    }

    private void OnDestroy()
    {
        aud = null;
        audioSrc = null;
    }
}
