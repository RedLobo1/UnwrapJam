using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    
    [SerializeField]float _damage = 10;
    [SerializeField] float _explosionRadius;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent<MechHealth>(out MechHealth mech))
        {
            Debug.Log("Boom");
            mech.Damage(_damage);
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(this.transform.position,_explosionRadius);
            foreach(Collider collider in colliders)
            {

                if(collider.TryGetComponent<IDestructible>(out IDestructible destructible))
                {
                    destructible.Destruct();
                }
            }

        }
    }
}
