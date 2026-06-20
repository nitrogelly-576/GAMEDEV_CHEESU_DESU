using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private DialogueUI _dialogueUI;

    [SerializeField]
    private List<DialogueLine> _dialogueLines =
        new List<DialogueLine>();

    private int _currentLine = 0;

    private void Start()
    {
        //Debug.Log("Dialogue Started");

        _dialoguePanel.SetActive(true);
        ShowCurrentLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_dialogueUI.IsTyping())
            {
                _dialogueUI.FinishTyping();
            }
            else
            {
                NextLine();
            }
        }
    }

    private void ShowCurrentLine()
    {
        DialogueLine line =
            _dialogueLines[_currentLine];

        Debug.Log(line.Character.CharacterName);

        _dialogueUI.SetLine(
            line.Character,
            line.Text
        );
    }

    private void NextLine()
    {
        _currentLine++;

        if (_currentLine >= _dialogueLines.Count)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    private void EndDialogue()
    {
        _dialoguePanel.SetActive(false);

        Debug.Log("Dialogue Finished!");
    }
}