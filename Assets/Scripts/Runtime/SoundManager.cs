using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource _source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        _source.PlayOneShot(_sound);
    }
}