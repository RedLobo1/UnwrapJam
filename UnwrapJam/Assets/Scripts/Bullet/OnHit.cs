using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer | _layerMask) == 0) return;
        other.gameObject.SetActive(false);
    }
}
