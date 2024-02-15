using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    
    [SerializeField]float _damage = 10;
    [SerializeField] float _explosionRadius;

    [SerializeField] ParticleSystem _explosion;

    private void OnEnable()
    {
        GetComponent<BulletMove>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        _explosion.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ParryBox") return;

        if (other.gameObject.TryGetComponent<MechHealth>(out MechHealth mech))
        {
            AudioManager.instance.Play("Hit");
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
                    AudioManager.instance.Play("TankProjectileHit");
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
                    AudioManager.instance.Play("TankProjectileHit");
                }
            }


        }

        StartCoroutine(Explode());

       

    }

    private IEnumerator Explode()
    {
        GetComponent<BulletMove>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        _explosion.Play();
        
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        
    }
}
