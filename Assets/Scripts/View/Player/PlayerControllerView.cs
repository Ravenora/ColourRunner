using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using strange.extensions.mediation.impl;

public class PlayerControllerView : View
{
    public Vector2 _startPosition;
    public Vector2 _lastPosition;
    public Rigidbody _rigidbody;
    public Material _material;

    public float _playerForwardSpeed;
    public float _playerRightSpeed;
    public TextMeshProUGUI _countText;

    public GateSignal GateSignal;
    public StickmanSignal StickmanSignal;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;

        GateSignal = new GateSignal();
        StickmanSignal = new StickmanSignal();
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
        if(dir == Vector2.zero)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            var moveMultiplier = dir.x / Screen.width;
            var moveDir = Vector3.right * moveMultiplier * _playerRightSpeed;
            _rigidbody.velocity = moveDir;
        }

        var moveForward = Vector3.forward * _playerForwardSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + moveForward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Gate>(out Gate gate))
        {
            _material.color = gate.Color;
            GateSignal.Dispatch(gate.Color);
        }

        if(other.gameObject.tag == "Stickman")
        {
            _countText.text = (Int32.Parse(_countText.text) + 1).ToString();
            StickmanSignal.Dispatch();
        }
    }
}
