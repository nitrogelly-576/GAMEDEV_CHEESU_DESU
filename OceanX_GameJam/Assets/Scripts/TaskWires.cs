using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWires : MonoBehaviour
{
    int[] _correctConnections;
    bool[] _connected;

    int _selectedWire;
    int _wiresConnected;

    private void Start()
    {
        _correctConnections = new int[]
        {
            0, 1, 2, 3
        };

        _connected = new bool[4];

        ShuffleConnections();
        PrintConnections();

        //TryConnect(1, 1);
    }

    private void ShuffleConnections()
    {
        for (int i = 0; i < _correctConnections.Length; i++) 
        {
            int randomIndex = Random.Range(i, _correctConnections.Length);

            int temp = _correctConnections[i];

            _correctConnections[i] = _correctConnections[randomIndex];

            _correctConnections[randomIndex] = temp;
        }
    }

    private void PrintConnections()
    {
        for (int i = 0; i < _correctConnections.Length; i++) 
        {
            Debug.Log($"Wire {i} -> Slot {_correctConnections[i]}");
        }
    }

    public void TryConnect(int wireIndex, int slotIndex)
    {
        if (_correctConnections[wireIndex] == slotIndex)
        {
            _connected[wireIndex] = true;
            _wiresConnected++;

            Debug.Log("Correct!");
            if (_wiresConnected >= 4)
            {
                Debug.Log("Task Completed!");
            }
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}
