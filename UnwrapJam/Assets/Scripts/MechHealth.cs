using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechHealth : MonoBehaviour, IDestructible
{
    public int _maxHealth = 100;
    private float _currentHealth;

    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (_currentHealth < 0) Destruct();
            if(_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }
    }

    private void Awake()
    {
       CurrentHealth = _maxHealth;
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
    }

    public void Destruct()
    {
        Die();

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
