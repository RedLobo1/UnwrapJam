using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BigMechMovement : MonoBehaviour
{
    private CharacterController _controller; // Reference to the CharacterController component

    private const float GRAVITY = -9.81f;
    private const float GRAVITY_MULTIPLIER = 3.0f;
    private float _velocity;

    public SmallRobotControler PlayerInputMaster;

    private InputAction _moveAction;

    private float _speed = 7f; // Speed of movement
    public float Speed
    {
        get => _speed;
        set
        {
            if (_speed == value) return;
            _speed = value;
            _speed = Mathf.Abs(_speed);
        }
    }

    void Awake()
    {
        PlayerInputMaster = new SmallRobotControler();
    }
    private void OnEnable()
    {
        _moveAction = PlayerInputMaster.BigMechPlayer.Move;

        //PlayerInputMaster.player.Enable();

        _moveAction.Enable();
    }

    private void OnDisable()
    {
        //PlayerInputMaster.player.Disable();
        _moveAction.Disable();
    }

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit hit, 50000);
        Vector3 pointWithoutY = new Vector3(hit.point.x, transform.position.y, hit.point.z);

        transform.LookAt(pointWithoutY);

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
            AudioManager.instance.Play("HeavySteps");
        }
       else
        {
            AudioManager.instance.Stop("HeavySteps");
        }
      
            
        direction.y = ApplyGravity();
        _controller.Move(Speed * Time.deltaTime * direction);
        


        
    }

    private float ApplyGravity()
    {
        if (_controller.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += GRAVITY * GRAVITY_MULTIPLIER * Time.deltaTime;
        }

        return _velocity;
    }
}
