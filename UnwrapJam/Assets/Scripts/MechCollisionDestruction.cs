
using UnityEngine;

public class MechCollisionDestruction : MonoBehaviour
{
    Collider parryCollider; //used to see if the parry is being used aka the collider is active

    private void Awake()
    {
        parryCollider = GetComponent<Collider>();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IDestructible>(out IDestructible destructible) && parryCollider.enabled)
        {
            destructible.Destruct();
        }
    }
  
}
