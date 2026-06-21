using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Panel References")]
    [SerializeField] private GameObject _wireTaskPanel;
    [SerializeField] private GameObject _fillTaskPanel;
    [SerializeField] private GameObject _valveTaskPanel;

    [Header("Booleans")]
    [SerializeField] private bool _wireTaskComplete;
    [SerializeField] private bool _fillTaskComplete;
    [SerializeField] private bool _valveTaskComplete;

    private bool _taskOpen;

    [Header("Timer & Scoring")]
    [SerializeField] public TMP_Text timer;
    [SerializeField] public float timeCount;

    [SerializeField] public TMP_Text _scoreText;
    [SerializeField] private float _score;

    public bool startTime;

    private void Start()
    {
        SoundManager.Instance.PlayGameMusic();
        startTime = false;
    }

    private void countDown()
    {
        timeCount -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeCount / 60);
        int seconds = Mathf.FloorToInt(timeCount % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        if(startTime)
        {
            countDown();
        }
        if ((_wireTaskComplete == true) || 
            (_fillTaskComplete == true) || 
            (_valveTaskComplete == true))
        {
            _wireTaskComplete = false;
            _fillTaskComplete = false;
            _valveTaskComplete = false;

            _score +=  100;

            _scoreText.text = string.Format("Score: ", _score);
        }
    }

    public void OpenWireTask()
    {

        if (_wireTaskComplete)
            return;

        _wireTaskPanel.SetActive(true);
        _taskOpen = true;

        Debug.Log("Wire Task Open!");
        startTime = true;
    }

    public void CompleteWireTask()
    {
        if (_wireTaskComplete)
            return;

        SoundManager.Instance.PlayTaskComplete();

        _wireTaskComplete = true;

        _wireTaskPanel.SetActive(false);
        _taskOpen = false;

        Debug.Log("Wire Task Complete!");
    }

    public void OpenFillTask()
    {
        if (_fillTaskComplete)
            return;

        _fillTaskPanel.SetActive(true);
        _taskOpen = true;

        Debug.Log("Wire Task Open!");
        startTime = true;
    }

    public void CompleteFillTask()
    {
        if (_fillTaskComplete)
            return;

        SoundManager.Instance.PlayTaskComplete();
        SoundManager.Instance.PlayOxygenEnd();

        _fillTaskComplete = true;

        _fillTaskPanel.SetActive(false);
        _taskOpen = false;

        Debug.Log("Fill Task Complete!");
    }
    public void OpenValveTask()
    {
        if (_valveTaskComplete)
            return;

        _valveTaskPanel.SetActive(true);
        _taskOpen = true;

        Debug.Log("Wire Task Open!");
        startTime = true;
    }

    public void CompleteValveTask()
    {
        if (_valveTaskComplete)
            return;

        SoundManager.Instance.PlayTaskComplete();

        _valveTaskComplete = true;

        ValveMinigame.Instance.TurnOnSpin();

        _valveTaskPanel.SetActive(false);
        _taskOpen = false;

        Debug.Log("Valve Task Complete!");
    }

    public bool IsTaskOpen()
    {
        startTime = true;
        return _taskOpen;
    }

    public void BTN_Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
