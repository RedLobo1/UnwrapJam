
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyAlertLogic : MonoBehaviour
{
    
    [SerializeField]float _sightRadius = 10f;
    Enemy _thisEnemy;
    NavMeshAgent _agent;
    [SerializeField]bool _isStatic = false;

    private void Start()
    {
       _agent = GetComponent<NavMeshAgent>();  
        _thisEnemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectBigMech();

        
    }

    private void DetectBigMech()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _sightRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("BigMech"))
            {
                _thisEnemy.SetTarget(collider.gameObject);
                if(!_isStatic)_agent.destination = collider.transform.position;
                return;
            }
        }
        _thisEnemy.SetTarget(null);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _sightRadius);
    }
}
