using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Talkable : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private List<DialogueLine> _dialogue;

    private bool _playerNearby;

    private void Update()
    {
        if (_playerNearby &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            Talk();
        }
    }

    public void Talk()
    {
        _dialogueManager.StartDialogue(_dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player can interact with NPC");

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
}
