using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 7f; // Speed of movement
    private CharacterController _controller; // Reference to the CharacterController component

    private float _gravity = -9.81f;
    private float _gravityMultiplier = 3.0f;
    private float _velocity;

    private float _turnSMoothTime = 0.1f;
    float _turnSmothVelocity;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        Vector3 direction = xDirection * Vector3.right + yDirection * Vector3.forward;
        //direction.y = 0f;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmothVelocity, _turnSMoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _controller.Move(_speed * Time.deltaTime * direction);
        }

        direction.y = ApplyGravity();

        
    }

    private float ApplyGravity()
    {
        if (_controller.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }

        return _velocity;
    }
}
