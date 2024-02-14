using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCollisionDestruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IDestructible>(out IDestructible destructible))
        {
            destructible.Destruct();
        }
    }
  
}
