using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Game Music")]
    [SerializeField] private AudioClip _gameMusic;

    [Header("Game SFX")]
    [SerializeField] private AudioClip _taskComplete;
    [SerializeField] private AudioClip _wireTape;
    [SerializeField] private AudioClip _OxygenFill;
    [SerializeField] private AudioClip _OxygenEnd;

    public void PlayGameMusic()
    {
        _musicSource.clip = _gameMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayTaskComplete()
    {
        _sfxSource.PlayOneShot(_taskComplete);
    }

    public void PlaywireTape()
    {
        _sfxSource.PlayOneShot(_wireTape);
    }

    public void PlayOxygenFill()
    {
        _sfxSource.PlayOneShot(_OxygenFill);
    }

    public void PlayOxygenEnd()
    {
        _sfxSource.PlayOneShot(_OxygenEnd);
    }
}