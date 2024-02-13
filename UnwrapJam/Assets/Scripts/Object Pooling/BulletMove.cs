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
    [SerializeField]private float speed = 2f;


    private void OnEnable()
    {
        hasParried = false;
    }
    private void Awake()
    {
        Dir = transform.forward;
    }
    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Dir;
    }

    public void Pary(Vector3 dir)
    {
        if (hasParried) return;
        Dir = dir;
        hasParried = true;
    }
}
