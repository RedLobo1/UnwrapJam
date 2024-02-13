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
        //if(Input.GetMouseButton(0) && fireHoldOff <= 0f)
        //{
        //    Vector2 dir = Random.insideUnitCircle;

        //    Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out RaycastHit hit, Camera.farClipPlane, _layerMask))
        //    {
        //        FireBullet(new(hit.point.x, transform.position.y, hit.point.z));
        //        fireHoldOff = fireTime;

        //    }
        //}

        if (fireHoldOff <= 0f)
        {
            Vector2 dir = Random.insideUnitCircle;
            
            FireBullet(new(dir.x, transform.position.y, dir.y));
            fireHoldOff = fireTime;
            
        }


        fireHoldOff -= Time.deltaTime;
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
