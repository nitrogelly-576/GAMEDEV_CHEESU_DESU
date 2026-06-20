using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _speakerText;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Image _portraitImage;

    [SerializeField] private float _typingSpeed = 0.03f;

    private Coroutine _typingCoroutine;

    private string _fullText;
    private bool _isTyping;

    public void SetLine(
    CharacterData character,
    string dialogue)
    {
        _speakerText.text = character.CharacterName;

        _portraitImage.sprite = character.Portrait;

        _portraitImage.SetNativeSize();

        _portraitImage.rectTransform.anchoredPosition = character.PortraitOffset;

        _portraitImage.rectTransform.localScale = Vector3.one * character.PortraitScale;

        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
        }

        _typingCoroutine = StartCoroutine(CO_TypeText(dialogue));
    }

    private IEnumerator CO_TypeText(string dialogue)
    {
        _isTyping = true;
        _fullText = dialogue;

        _dialogueText.text = "";

        foreach (char letter in dialogue)
        {
            _dialogueText.text += letter;

            yield return new WaitForSeconds(_typingSpeed);
        }

        _isTyping = false;
        _typingCoroutine = null;
    }

    public bool IsTyping()
    {
        return _isTyping;
    }

    public void FinishTyping()
    {
        if (!_isTyping)
            return;

        StopCoroutine(_typingCoroutine);

        _dialogueText.text = _fullText;

        _isTyping = false;
    }
}
