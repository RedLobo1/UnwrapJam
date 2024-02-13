using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera Camera;
    [SerializeField]
    private LayerMask _layerMask;
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
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.Log("before ray");
        if(Physics.Raycast(ray, out RaycastHit hit,Camera.farClipPlane,_layerMask) )
        {
            Debug.Log("after ray");

            Vector3 point = hit.point;
            Vector3 fireAngle = point - transform.position;
            if (fireAngle.magnitude <= 0.001f)
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
}
