using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 Dir
    {
        get => _dir;

        set
        {
            _dir = value;
            _dir = new(_dir.x, 0, _dir.z);
            _dir = _dir.normalized;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            _speed = Mathf.Abs(_speed);
        }
    }

    private bool _hasParried = false;
    private Vector3 _dir;
    [SerializeField]private float _speed = 2f;


    private void OnEnable()
    {
        _hasParried = false;
    }
    private void Awake()
    {
        Dir = transform.forward;
        _hasParried = false;
    }
    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Dir;
    }

    public void Pary(Vector3 dir)
    {
        if (_hasParried) return;
        Dir = dir;
        _hasParried = true;
        AudioManager.instance.Play("Parry");
    }
}
