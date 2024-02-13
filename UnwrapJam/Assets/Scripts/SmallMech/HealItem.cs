using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour, IPickUpAble
{
    bool _isPickedUpOnce;

    bool _isPuttedDown = true;
    public void Interact()
    {
        Debug.Log("Interacted");

        _isPickedUpOnce = true;
        _isPuttedDown = false;
    }

    public void Selecet()
    {
        if (!_isPuttedDown) return;
        Debug.Log("Selected");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isPickedUpOnce)
        {
            _isPuttedDown = true;

            if (collision.gameObject.TryGetComponent<MechHealth>(out MechHealth mechHealthScript))
            {
                mechHealthScript.Heal(10);

                Destroy(gameObject);
            }
        }
    }


}
