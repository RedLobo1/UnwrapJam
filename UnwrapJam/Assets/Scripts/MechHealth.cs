using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechHealth : MonoBehaviour
{
    public int _maxHealth = 100;
    private float _currentHealth;

    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (_currentHealth < 0) Die();
            if(_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }
    }
    private void Update()
    {
        _currentHealth -= Time.deltaTime * 2;
    }

    private void Awake()
    {
       CurrentHealth = _maxHealth;
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
    }

    

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        //open GameOverUI
        //LockiScreen
    }

    public void Heal(float healAmount)
    {
        CurrentHealth += healAmount;
    }
}
