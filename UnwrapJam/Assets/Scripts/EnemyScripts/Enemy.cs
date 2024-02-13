using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDestructible
{
    public UnityEvent Shoot;

    [SerializeField] float damage;
    [SerializeField] int maxHealth = 100;
    [SerializeField] float currentHealth;

    [SerializeField] public float _shootingRange = 2;
    [SerializeField] public float _shootingCooldown = 3f;
    private GameObject _target;

    bool _enemyInRange = false;
    bool _isShooting = false;   


    

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(_target!=null && Vector3.Distance(this.transform.position, _target.transform.position)<=_shootingRange)
        {
            Debug.Log("Shooting");
            Shoot?.Invoke();

            _enemyInRange = true;
        }
        else _enemyInRange = false;

        if(_enemyInRange==true && _isShooting==false)
        {
            StartCoroutine(ShootCountdown());
            _isShooting = true;
        }
    }

    private IEnumerator ShootCountdown()
    {
        yield return new WaitForSeconds(_shootingCooldown);
        Debug.Log("Shot Fired");
        Shoot?.Invoke();
        _isShooting = false;
    }

    public void SetTarget(GameObject go)
    {
        _target = go;
    }

    public IEnumerator Die()
    {
        //play animation
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);

    }


}
