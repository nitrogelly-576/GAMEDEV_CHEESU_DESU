using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.dKey.isPressed)
            horizontal = 1f;

        if (Keyboard.current.sKey.isPressed)
            vertical = -1f;

        if (Keyboard.current.wKey.isPressed)
            vertical = 1f;

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.position += movement.normalized * _moveSpeed * Time.deltaTime;
    }
}
