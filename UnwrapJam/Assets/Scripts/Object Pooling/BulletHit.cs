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

        if (other.gameObject.tag == "ParryBox") return;

        if (other.gameObject.TryGetComponent<MechHealth>(out MechHealth mech))
        {
            Debug.Log("Boom");
            mech.Damage(_damage);
        }
        else if(other.gameObject.tag != "ParryBox")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (other.gameObject.TryGetComponent<IDestructible>(out IDestructible destructible))
                {
                    Debug.Log("Killing Enemy");
                    destructible.Destruct();
                }
            }

            Debug.Log("Non-Mech");
            Collider[] colliders = Physics.OverlapSphere(this.transform.position,_explosionRadius);
            foreach(Collider collider in colliders)
            {
                Debug.Log("should destroy");
                if (collider.TryGetComponent<IDestructible>(out IDestructible destructible))
                {
                    Debug.Log("Killing Enemy");
                    destructible.Destruct();
                }
            }


        }

        this.gameObject.SetActive(false);

    }
}
