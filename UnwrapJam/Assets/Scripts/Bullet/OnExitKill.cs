
using UnityEngine;

public class OnExitKill : MonoBehaviour
{
    [SerializeField]
    private LayerMask _LayerMask;
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.layer & _LayerMask) != 0) return;
        other.gameObject.SetActive(false);
    }
}
