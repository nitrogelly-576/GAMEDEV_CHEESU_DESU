using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum WireColor
{
    Red,
    Blue,
    Green,
    Yellow,
}

public class WireVisual : MonoBehaviour
{
    [SerializeField] private RectTransform _leftSocket;
    [SerializeField] private RectTransform _wirePlug;

    [SerializeField] private Image _wireBodyImage;
    [SerializeField] private Color _wireColor;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        _wireBodyImage.color = _wireColor;
    }

    private void Update()
    {
        UpdateWire();
    }

    private void UpdateWire()
    {
        Vector2 startPosition = _leftSocket.anchoredPosition;
        Vector2 endPosition = _wirePlug.anchoredPosition;

        Vector2 direction = endPosition - startPosition;

        float distance = direction.magnitude;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _rectTransform.anchoredPosition = startPosition;

        _rectTransform.rotation = Quaternion.Euler(0, 0, angle);


        _rectTransform.sizeDelta = new Vector2(distance, _rectTransform.sizeDelta.y);
    }
}
