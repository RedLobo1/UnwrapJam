using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField]
    private Collider _parryCollider;
    [SerializeField]
    private LayerMask _layerMask;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 center = _parryCollider.bounds.center;
            Vector3 halfExtends = _parryCollider.bounds.extents;

            Collider[] hitColliders  = Physics.OverlapBox(center, halfExtends,Quaternion.identity,_layerMask);

            if(hitColliders.Length > 0 )
            {
                foreach(Collider collider in hitColliders)
                {
                    if (!collider.TryGetComponent(out BulletMove bulletMove)) continue;
                    bulletMove.pary();

                }
            }
        }
    }
}
