using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionTimer : MonoBehaviour
{
    [SerializeField]
    private float _duration = 5;
    private float _time = 0;
    private void Update()
    {
        _time += Time.deltaTime;
        if(_time >= _duration)
            gameObject.SetActive(false);
    }
}
