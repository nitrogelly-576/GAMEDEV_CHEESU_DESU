using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSocket : MonoBehaviour
{
    public int SocketIndex;

    public RectTransform RectTransform;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}
