using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool _taskCompleted;

    public void CompleteTask()
    {
        if (_taskCompleted)
        {
            return;
        }

        _taskCompleted = true;

        Debug.Log("Task Complete!");
    }
}
