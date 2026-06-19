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
    [SerializeField] private AudioClip _enemyDeathSFX;

    public void PlayGameMusic()
    {
        _musicSource.clip = _gameMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayEnemyDeath()
    {
        _sfxSource.PlayOneShot(_enemyDeathSFX);
    }
}