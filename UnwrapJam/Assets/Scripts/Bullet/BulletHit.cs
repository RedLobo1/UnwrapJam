using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    
    [SerializeField]float _damage = 10;
    [SerializeField] float _explosionRadius;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ParryBox")) return;

        if (other.gameObject.TryGetComponent(out MechHealth mech))
        {
            Debug.Log("Boom");
            mech.Damage(_damage);
        }
        else if(gameObject.TryGetComponent(out BulletMove bulletMove) && bulletMove.WasParried)
        {
            Collider[] colliders = Physics.OverlapSphere(this.transform.position,_explosionRadius);
            foreach(Collider collider in colliders)
            {

                if(collider.TryGetComponent(out IDestructible destructible))
                {
                    destructible.Destruct();
                }
            }


        }

        gameObject.SetActive(false);

    }
}
