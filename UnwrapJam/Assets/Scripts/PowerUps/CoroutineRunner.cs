using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public static CoroutineRunner Runner;

    private void Awake()
    {
        if(Runner == null)
        {
            Runner = this;
        }
        else
        {
            Runner = gameObject.AddComponent<CoroutineRunner>();
        }
    }
    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
