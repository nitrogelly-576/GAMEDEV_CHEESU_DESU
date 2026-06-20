using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OpenWireTask()
    {
        if (_wireTaskComplete)
            return;

        _wireTaskPanel.SetActive(true);
        _taskOpen = true;

        Debug.Log("Wire Task Open!");
    }

    public void CompleteWireTask()
    {
        if (_wireTaskComplete)
            return;

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
    }

    public void CompleteFillTask()
    {
        if (_fillTaskComplete)
            return;

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
    }

    public void CompleteValveTask()
    {
        if (_valveTaskComplete)
            return;

        _valveTaskComplete = true;

        _valveTaskPanel.SetActive(false);
        _taskOpen = false;

        Debug.Log("Valve Task Complete!");
    }

    public bool IsTaskOpen()
    {
        return _taskOpen;
    }
}
