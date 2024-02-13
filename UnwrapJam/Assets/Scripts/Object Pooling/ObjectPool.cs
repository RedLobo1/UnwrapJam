using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> _pulledObjects;
    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    private bool _canExpand = false;
    [SerializeField]
    private int _countToPool;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _pulledObjects = new List<GameObject>();
        for (int i = 0; i < _countToPool; i++)
        {
            GameObject ob = Instantiate(_objectToPool, transform);
            ob.SetActive(false);
            _pulledObjects.Add(ob);
        }
    }

    public static GameObject GetPooledObject()
    {
        for (int i = 0; i < instance._pulledObjects.Count; i++)
        {
            if (!instance._pulledObjects[i].activeInHierarchy)
                return instance._pulledObjects[i];
        }
        if(instance._canExpand)
        {
            GameObject ob = Instantiate(instance._objectToPool,instance.transform);
            ob.SetActive(false);
            instance._pulledObjects.Add(ob);
            return ob;
        }
        return null;
    }

}
