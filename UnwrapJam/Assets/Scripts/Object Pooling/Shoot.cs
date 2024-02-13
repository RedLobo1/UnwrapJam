using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera Camera;
    [Range(0, 1000)]
    public int BulletsPerSecond = 1;
    private float fireTime;
    private float fireHoldOff;

    private void Update()
    {
        fireTime = 1f / BulletsPerSecond;
        if(Input.GetMouseButton(0) && fireHoldOff <= 0f)
        {
            FireBullet();
            fireHoldOff = fireTime;
        }
        fireHoldOff -= Time.deltaTime;
    }

    void FireBullet()
    {
        Vector3 point = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        point.y = transform.position.y;
        Vector3 fireAngle = point - transform.position;
        if(fireAngle.magnitude <= 0.001f)
        {
            fireAngle = transform.forward;
        }
        GameObject newBullet = ObjectPool.GetPooledObject();
        if (newBullet == null) return;
        newBullet.transform.position = transform.position + fireAngle.normalized;
        newBullet.transform.LookAt(transform.position + fireAngle);
        newBullet.SetActive(true);
    }
}
