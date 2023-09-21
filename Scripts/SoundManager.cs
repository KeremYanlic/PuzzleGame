using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonobehaviour<SoundManager>
{
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clipToPlay, float volume)
    {
        audioSource.PlayOneShot(clipToPlay, volume);
    }

}
