using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyAlertLogic : MonoBehaviour
{
    
    [SerializeField]float _sightRadius = 10f;
    bool _hasSpottedEnemy = false;
    Enemy _thisEnemy;
    NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();  
        _thisEnemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        _hasSpottedEnemy=false;
    }

    // Update is called once per frame
    void Update()
    {
        DetectBigMech();

        
    }

    private void DetectBigMech()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, _sightRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "BigMech")
            {
                _hasSpottedEnemy = true;
                _thisEnemy.SetTarget(collider.gameObject);
                _agent.destination = collider.transform.position;
                return;
            }
        }
        _hasSpottedEnemy = false;
        _thisEnemy.SetTarget(null);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, _sightRadius);
    }
}
