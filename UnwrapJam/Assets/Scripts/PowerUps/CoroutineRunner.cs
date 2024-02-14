using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner _Runner;
    public static CoroutineRunner Runner
    {
        get
        {
            if(Runner == null)
            {
                GameObject CorutineRunnerGameObject = new GameObject("CorutineRunner");
                _Runner = CorutineRunnerGameObject.AddComponent<CoroutineRunner>();
                DontDestroyOnLoad(CorutineRunnerGameObject);
            }
            return _Runner;
        }
    }
    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
