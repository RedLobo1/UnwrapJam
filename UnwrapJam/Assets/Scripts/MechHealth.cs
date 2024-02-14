using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechHealth : MonoBehaviour, IDestructible
{
    public int _maxHealth = 100;
    public float _currentHealth;


    private void Awake()
    {
       _currentHealth = _maxHealth;
    }

    public void Damage(float damageAmount)
    {
        _currentHealth -= damageAmount;
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
        _currentHealth += healAmount;
    }

    private void Update()
    {
        if (_currentHealth < 0)
        {
             
        }
    }

   
        



}
