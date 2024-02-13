using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BigMechMovement : MonoBehaviour
{
    private float _speed = 7f; // Speed of movement
    private CharacterController _controller; // Reference to the CharacterController component

    private float _gravity = -9.81f;
    private float _gravityMultiplier = 3.0f;
    private float _velocity;



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
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 50000);
        Vector3 pointWithoutY = new Vector3(hit.point.x, transform.rotation.y, hit.point.z);

        transform.LookAt(pointWithoutY);

    }

    private void MovePlayer()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        Vector3 direction = xDirection * Vector3.right + yDirection * Vector3.forward;
        //direction.y = 0f;

       
            
            _controller.Move(_speed * Time.deltaTime * direction);
        

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
