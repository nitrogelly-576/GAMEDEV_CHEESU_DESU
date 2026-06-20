using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillMinigame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] BoxMoving box;

    [SerializeField] private RectTransform _meterFill;
    [SerializeField] private GameObject movingBox;
    [SerializeField] private GameObject targetBox;

    [Header("Variables")]
    [SerializeField] public int hitBox;
    [SerializeField] public int meterMax = 300;

    [Header("Meter")]
    [SerializeField] private int _meterAmount;
    [SerializeField] private int meterFill;
    [SerializeField] private int meterLoss;

    [SerializeField] private float randomSpeed = 20.0f;

    private bool _spacePressed;

    void Start()
    {
        _meterAmount = 0;
    }

    void Update()
    {
        InputListen();
        CheckHit();
    }

    private void UpdateMeter()
    {
        _meterFill.sizeDelta = new Vector2(_meterAmount, _meterFill.sizeDelta.y);
    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Space pressed");

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space released, box at " + movingBox.transform.position.x + " | Target box at " + targetBox.transform.position.x);
            _spacePressed = true;
        }
    }

    private void CheckHit()
    {

        if (_spacePressed)
        {
            if (movingBox.transform.position.x < (targetBox.transform.position.x + hitBox) 
                && movingBox.transform.position.x > (targetBox.transform.position.x - hitBox))
            {
                Debug.Log("Meter filling");
                _meterAmount += meterFill;

                if (_meterAmount >= meterMax)
                {
                    _meterAmount = meterMax;
                    GameManager.Instance.CompleteFillTask();
                }

                float speedChange = Random.Range(-randomSpeed, randomSpeed);

                box.AddSpeed(speedChange);

                Debug.Log($"Box speed at {box.GetBoxSpeed()}");

            }
            else
            {
                _meterAmount -= meterFill;

                if (_meterAmount < 0)
                {

                    _meterAmount = 0;

                }
            }

            UpdateMeter();
            Debug.Log("Meter at " + _meterAmount);
            _spacePressed = false;

        }

    }
}