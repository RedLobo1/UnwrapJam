using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 2f;
    private bool hasParried = false;

    private void Update()
    {
        transform.position += Speed * Time.deltaTime * transform.forward;
    }

    public void pary()
    {
        if (hasParried) return;
        Speed *= -1;
        hasParried = true;
    }
}
