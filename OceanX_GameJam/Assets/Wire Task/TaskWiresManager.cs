using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWiresManager : MonoBehaviour
{
    [SerializeField] private RectTransform[] _rightSockets;
    private int _connectedWires;

    [SerializeField] 
    private float[] _socketYPositions =
    {
        120f,
        40f,
        -40f,
        -120f
    };

    private void Start()
    {
        ShuffleSocketPositions();
    }

    private void ShuffleSocketPositions()
    {
        for (int i = 0; i < _socketYPositions.Length; i++)
        {
            int randomIndex =
                Random.Range(i, _socketYPositions.Length);

            float temp = _socketYPositions[i];

            _socketYPositions[i] = _socketYPositions[randomIndex];

            _socketYPositions[randomIndex] = temp;
        }

        for (int i = 0; i < _rightSockets.Length; i++)
        {
            Vector2 position = _rightSockets[i].anchoredPosition;

            position.y = _socketYPositions[i];

            _rightSockets[i].anchoredPosition = position;
        }
    }

    public void ConnectWire()
    {
        _connectedWires++;

        Debug.Log($"Connected Wires: {_connectedWires}");

        if (_connectedWires >= 4)
        {
            GameManager.Instance.CompleteTask();
        }
    }
}