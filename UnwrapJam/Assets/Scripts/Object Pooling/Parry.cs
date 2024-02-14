using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField]
    private Collider _parryCollider;
    [SerializeField]
    private LayerMask _layerMask;

    private Collider[] _colliders;

    [SerializeField]
    private Vector3[] _forwardParryPath;
    [SerializeField, Range(0.2f,3f)]
    private float _forwardParryDuration = 0.5f;
    [SerializeField]
    private Vector3[] _arcParryPath;
    [SerializeField, Range(0.2f, 3f)]
    private float _arcParryDuration = 0.5f;

    private Coroutine _currentCorutinea;


    private void Awake()
    {
        _colliders = new Collider[40];
    }
    private void Update()
    {
        if (_currentCorutinea != null) return;

        if(Input.GetMouseButtonDown(0))
        {
            _currentCorutinea = StartCoroutine(ForardParry());
        }
        if (Input.GetMouseButtonDown(1))
        {
            _currentCorutinea = StartCoroutine(ArcParry());
        }
    }

    public void ParryThisYouFilthyCasual()
    {
        
        Vector3 center = _parryCollider.bounds.center;
        Vector3 halfExtends = _parryCollider.bounds.extents;

        if (Physics.OverlapBoxNonAlloc(center, halfExtends, _colliders, Quaternion.identity, _layerMask) != 0)
        {
            foreach (Collider collider in _colliders)
            {
                if (collider == null) continue;
                if (!collider.TryGetComponent(out BulletMove bulletMove)) continue;
                Vector3 dir =  _parryCollider.transform.position - collider.transform.position;
                Quaternion rot = quaternion.Euler(1, 0, 0);
                bulletMove.Pary(rot * dir);
            }
        }
        
    }

    public IEnumerator ForardParry()
    {
        float t = 0;
        while(t < _forwardParryDuration)
        {
            t += Time.deltaTime;
            float tvalue = t / _forwardParryDuration;
            tvalue = tvalue * tvalue * tvalue * (tvalue * (6.0f * tvalue - 15.0f) + 10.0f);
            _parryCollider.transform.position = Vector3.Lerp(transform.position + _forwardParryPath[0], transform.position + _forwardParryPath[1], tvalue);
            ParryThisYouFilthyCasual();
            yield return null;
        }
        _parryCollider.transform.position = transform.position + _forwardParryPath[0];
        _currentCorutinea = null;
    }
    public IEnumerator ArcParry()
    {
        float t = 0;
        while (t < _arcParryDuration)
        {
            t += Time.deltaTime;
            float tvalue = t / _arcParryDuration;
            tvalue = tvalue * tvalue * tvalue * (tvalue * (6.0f * tvalue - 15.0f) + 10.0f);
            _parryCollider.transform.position = TripelLerp(_arcParryPath,tvalue);
            ParryThisYouFilthyCasual();
            yield return null;
        }
        _parryCollider.transform.position = transform.position + _arcParryPath[0];
        _currentCorutinea = null;
    }

    private Vector3 TripelLerp(Vector3[] p, float t) => Vector3.Lerp(
            Vector3.Lerp(transform.position + p[0], transform.position + p[1], t),
            Vector3.Lerp(transform.position + p[1], transform.position + p[2], t),
            t);
    private void OnDrawGizmos()
    {
        float radius = 0.1f;
        Gizmos.color = Color.red;
        for (int i = 0; i < _forwardParryPath.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + _forwardParryPath[i], radius);
        }
        Gizmos.color = Color.blue;
        for (int i = 0; i < _arcParryPath.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + _arcParryPath[i], radius);
        }

    }
}
