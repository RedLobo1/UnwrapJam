
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private bool _followX, _followY, _followZ;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offsetMovement;
    private void LateUpdate()
    {
        transform.position += _offsetMovement * Time.deltaTime;  
        transform.position = (_followX ? Vector3.right * _target.position.x : Vector3.right * transform.position.x) +
                             (_followZ ? Vector3.forward * _target.position.z : Vector3.forward * transform.position.z) +
                             (_followY ? Vector3.up * _target.position.y : Vector3.up * transform.position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
