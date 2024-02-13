using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigMechParryLogic : MonoBehaviour
{
    [SerializeField] public UnityEvent Parry;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Parry.Invoke();
        }    
    }
}