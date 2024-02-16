
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool pool;

    private List<GameObject> _pulledObjects;
    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    private bool _canExpand = false;
    [SerializeField]
    private int _countToPool;
    private void Awake()
    {
        if(pool == null)
        {
            pool = this;
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
        for (int i = 0; i < pool._pulledObjects.Count; i++)
        {
            if (!pool._pulledObjects[i].activeInHierarchy)
                return pool._pulledObjects[i];
        }
        if(pool._canExpand)
        {
            GameObject ob = Instantiate(pool._objectToPool,pool.transform);
            ob.SetActive(false);
            pool._pulledObjects.Add(ob);
            return ob;
        }
        return null;
    }

}
