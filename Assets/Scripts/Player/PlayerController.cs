using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Vector2 _startPosition;
    public Vector2 _lastPosition;
    public Rigidbody _rigidbody;

    public float _playerForwardSpeed;
    public float _playerRightSpeed;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();   
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                _lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _startPosition = Vector2.zero;
                _lastPosition = Vector2.zero;
            }
        }
    }

    void FixedUpdate()
    {
        var dir = (_lastPosition - _startPosition);
        var moveMultiplier = dir.x / Screen.width / 2;
        var moveDir = Vector3.MoveTowards(_rigidbody.position, _rigidbody.position + Vector3.right * moveMultiplier * _playerRightSpeed * Time.fixedDeltaTime, 1f);
        var moveForward = Vector3.forward * _playerForwardSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(moveDir + moveForward);
    }
}
