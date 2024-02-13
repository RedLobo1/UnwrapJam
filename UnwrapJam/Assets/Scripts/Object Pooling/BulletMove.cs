using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * transform.forward;
    }
}
