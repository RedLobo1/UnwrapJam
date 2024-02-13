using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCollisionDestruction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDestructible>(out IDestructible destructible))
        {
            destructible.Destroy();
        }
    }
}
