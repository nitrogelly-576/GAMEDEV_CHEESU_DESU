using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string _taskName;

    private bool _playerNearby;

    private void Update()
    {
        if (_playerNearby &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player can interact with Machine");

            _playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNearby = false;
        }
    }

    public void Interact()
    {
        switch (_taskName)
        {
            case "Wire":
                GameManager.Instance.OpenWireTask();
                break;

            case "Fill":
                GameManager.Instance.OpenFillTask();
                break;

            case "Valve":
                GameManager.Instance.OpenValveTask();
                break;
        }
    }
}
