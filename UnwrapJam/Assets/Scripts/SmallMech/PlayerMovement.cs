using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 7f; // Speed of movement
    [SerializeField]private CharacterController _controller; // Reference to the CharacterController component

    private float _gravity = -9.81f;
    private float _gravityMultiplier = 3.0f;
    private float _velocity;

    private float _turnSMoothTime = 0.1f;
    float _turnSmothVelocity;

    [SerializeField]Animator _animator;


    public SmallRobotControler PlayerInputMaster;

    private InputAction _moveAction;

    void Awake()
    {
        PlayerInputMaster = new SmallRobotControler();

    }

    private void OnEnable()
    {
        _moveAction = PlayerInputMaster.player.Look;

        //PlayerInputMaster.player.Enable();

        _moveAction.Enable();
    }

    private void OnDisable()
    {
        //PlayerInputMaster.player.Disable();
        _moveAction.Disable();
    }



    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 inputVector = _moveAction.ReadValue<Vector2>();

        float xDirection = inputVector.x;
        float yDirection = inputVector.y;
        Vector3 direction = xDirection * Vector3.right + yDirection * Vector3.forward;
        //direction.y = 0f;

        if(_moveAction.IsPressed())
        {
            _animator.SetBool("isMoving", true);
        }
        else _animator.SetBool("isMoving", false);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmothVelocity, _turnSMoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            direction.y = ApplyGravity();

            _controller.Move(_speed * Time.deltaTime * direction);
        }

        

        
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
