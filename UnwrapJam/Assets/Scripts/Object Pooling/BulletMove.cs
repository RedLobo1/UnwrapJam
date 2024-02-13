using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 Dir
    {
        get => dir;
        set
        {
            dir = value;
            dir = dir.normalized;
        }
    }

    public float Speed 
    { 
        get => speed; 
        set => speed = value; 
    }

    private bool hasParried = false;
    private Vector3 dir;
    private float speed = 2f;


    private void Awake()
    {
        Dir = transform.forward;
    }
    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Dir;
    }

    public void Pary()
    {
        if (hasParried) return;
        Dir *= -1;
        hasParried = true;
    }
}