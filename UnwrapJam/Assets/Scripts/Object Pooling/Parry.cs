using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField]
    private Collider _parryCollider;
    [SerializeField]
    private LayerMask _layerMask;

    private Collider[] _colliders;

    private void Awake()
    {
        _colliders = new Collider[40];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 center = _parryCollider.bounds.center;
            Vector3 halfExtends = _parryCollider.bounds.extents;

            if(Physics.OverlapBoxNonAlloc(center, halfExtends,_colliders, Quaternion.identity, _layerMask) != 0)
            {
                foreach(Collider collider in _colliders)
                {
                    if(collider == null) continue;
                    if (!collider.TryGetComponent(out BulletMove bulletMove)) continue;
                    bulletMove.Pary();
                }
            }
        }
    }
}
