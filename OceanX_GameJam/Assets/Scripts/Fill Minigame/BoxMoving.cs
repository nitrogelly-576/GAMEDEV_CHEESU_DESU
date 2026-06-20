using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoving : MonoBehaviour
{

    [SerializeField] private float _speed = 30f;
    [SerializeField] private int _uTurnLimit = 100;

    private Vector3 movement;

    void Start()
    {
        movement = new Vector3(_speed, 0, 0);
    }

    void Update()
    {
        this.gameObject.transform.Translate(movement * Time.deltaTime * 5);
        LeftRight();
    }

    private void LeftRight()
    {
        if (this.gameObject.transform.localPosition.x > _uTurnLimit)
        {
            movement = new Vector3(-_speed, 0, 0);
        }
        if (this.gameObject.transform.localPosition.x < -_uTurnLimit)
        {
            movement = new Vector3(_speed, 0, 0);
        }
    }

    public void AddSpeed(float amount)
    {
        _speed += amount;

        movement = new Vector3(Mathf.Sign(movement.x) * _speed, 0, 0);
    }

    public float GetBoxSpeed()
    {
        return _speed;
    }
}
