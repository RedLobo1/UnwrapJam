using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAbleItem : MonoBehaviour, IPickUpAble
{    
    public PowerUpAffects powerup;

    private bool _isPickedUpOnce;
    private bool _isGrounded = true;


    public void Interact()
    {

        _isPickedUpOnce = true;
        _isGrounded = false;
    }

    public void Selecet()
    {
        if (!_isGrounded) return;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isPickedUpOnce) return;
        _isGrounded = true;
        if (!collision.gameObject.CompareTag("BigMech")) return;
        powerup.Apply(collision.gameObject);
        Destroy(gameObject);        
    }


}
