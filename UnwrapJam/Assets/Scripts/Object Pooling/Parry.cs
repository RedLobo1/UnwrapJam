using System;
using System.Collections;


using UnityEngine;
using Random = UnityEngine.Random;

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
    [SerializeField,Range(0,90)]
    private float _parryVariety = 30;

    private Coroutine _currentCorutinea;



    private void Awake()
    {
        _colliders = new Collider[40];
    }
    public void ForwardParry()
    {
        if (_currentCorutinea != null) return;
        _currentCorutinea = StartCoroutine(ForwardParry(OffsetLerp, _forwardParryPath, _forwardParryDuration));
    }
    public void ArcParry()
    {
        if (_currentCorutinea != null) return;
        _currentCorutinea = StartCoroutine(ForwardParry(TripelOffsetLerp, _arcParryPath, _arcParryDuration));
    }

    public void ParryThisYouFilthyCasual()
    {
        
        Vector3 center = _parryCollider.transform.position;
        Vector3 halfExtends = _parryCollider.bounds.extents;

        if (Physics.OverlapBoxNonAlloc(center, halfExtends, _colliders, Quaternion.identity, _layerMask) != 0)
        {
            foreach (Collider collider in _colliders)
            {
                if (collider == null) continue;
                if (!collider.TryGetComponent(out BulletMove bulletMove)) continue;
                Vector3 dir =  _parryCollider.transform.position - transform.position;
                Quaternion rot = Quaternion.Euler(0, Random.Range(-_parryVariety, _parryVariety), 0);
                bulletMove.Pary(rot * dir);
            }
        }
        
    }

    public IEnumerator ForwardParry(Func<Vector3[], float, Vector3> eval,Vector3[] points, float duration )
    {
        float t = 0;
        while(t < duration)
        {
            t += Time.deltaTime;
            float tvalue = t / duration;
            _parryCollider.transform.position = eval(points, SmoothStep(tvalue));
            ParryThisYouFilthyCasual();
            yield return null;
        }
        _parryCollider.transform.position = transform.position;
        _currentCorutinea = null;
    }
    private Vector3 TripelOffsetLerp(Vector3[] p, float t) => Vector3.Lerp(
            Vector3.Lerp(GetOffsetInLocalSpace(p[0]), GetOffsetInLocalSpace(p[1]), t),
            Vector3.Lerp(GetOffsetInLocalSpace(p[1]), GetOffsetInLocalSpace(p[2]), t),
            t);
    private Vector3 OffsetLerp(Vector3[] p, float t) => Vector3.Lerp(GetOffsetInLocalSpace(p[0]),GetOffsetInLocalSpace(p[1]), t);

    private Vector3 GetOffsetInLocalSpace(Vector3 p) => transform.position + transform.right * p.x + transform.forward * p.z;

    private float SmoothStep(float t) => t * t * t * (t * (6.0f * t - 15.0f) + 10.0f);
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
