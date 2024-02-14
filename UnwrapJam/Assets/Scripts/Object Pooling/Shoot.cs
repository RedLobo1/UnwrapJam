using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera Camera;
    [SerializeField]
    private LayerMask _layerMask;
    public void FireForward()
    {
        FireBullet(transform.position);
    }
    public void FireBullet(Vector3 point)
    {    
        Vector3 fireAngle = point - transform.position;
        if (fireAngle.magnitude <= 0.001f)
        {
            fireAngle = transform.forward;
        }
        GameObject newBullet = ObjectPool.GetPooledObject();
        if (newBullet == null) return;
        newBullet.transform.position = transform.position + fireAngle.normalized;
        newBullet.GetComponent<BulletMove>().Dir = fireAngle;

        newBullet.SetActive(true);
    }
}
