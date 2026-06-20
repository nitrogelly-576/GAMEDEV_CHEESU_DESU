using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class WirePlug : MonoBehaviour, 
    IPointerDownHandler,
    IDragHandler,
    IEndDragHandler
{
    [SerializeField] private TaskWiresManager _taskWiresManager;
    [SerializeField] private RightSocket _rightSocket;

    private RectTransform _rectTransform;
    private Vector2 _startPosition;

    private bool _isConnected;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _startPosition = _rectTransform.anchoredPosition;
    }

    private void Start()
    {
        Debug.Log(
            $"{name} local position: {_rectTransform.anchoredPosition}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Grabbed!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isConnected)
            return;

        _rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        float distance =
            Vector2.Distance(_rectTransform.position, _rightSocket.RectTransform.position);

        if (distance < 50f)
        {
            SnapToSocket();

            _isConnected = true;

            _taskWiresManager.ConnectWire();

            Debug.Log("Connected!");
        }
        else
        {
            Debug.Log("Retracting!");

            _rectTransform.anchoredPosition = _startPosition;
        }
    }

    private void SnapToSocket()
    {
        _rectTransform.position = _rightSocket.RectTransform.position;
    }
}