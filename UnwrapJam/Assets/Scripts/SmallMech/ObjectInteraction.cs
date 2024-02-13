using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public static bool IsCarryingObject;

    GameObject _objectBeingCarried;

    Rigidbody _rigidbodyOfCarriedObject;

    //private Collider[] _colliders;

    //private void Awake()
    //{
    //    _colliders = new Collider[5];
    //}

    void Update()
    {
        if (IsCarryingObject)
        {
            CarryPickedUpObject();
        }

        if (Input.GetKeyDown(KeyCode.E) && IsCarryingObject)
        {
            IsCarryingObject = false;
            

            _rigidbodyOfCarriedObject.isKinematic = false;
            
            ThrowCarriedObject();


        }

        CheckForObjectsToInteractWith();


    }

    
    private void ThrowCarriedObject()
    {


        Rigidbody projectileRb = _rigidbodyOfCarriedObject;

        

        projectileRb.AddForce(transform.forward * 15f, ForceMode.Impulse);
    }

    private void CarryPickedUpObject()
    {
        _objectBeingCarried.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        _objectBeingCarried.transform.rotation = transform.rotation;

        _objectBeingCarried.transform.Rotate(new Vector3(-90, 0, 0));
    }

    private void CheckForObjectsToInteractWith()
    {
        Collider[] interactables = Physics.OverlapSphere(transform.position + transform.forward * 1.5f, 1.5f);
        //if (Physics.OverlapSphereNonAlloc(transform.position + transform.forward * 1.5f, 1.5f, _colliders) == 0) return;
        foreach (Collider col in interactables)
        {
            if (!col.TryGetComponent<IPickUpAble>(out IPickUpAble interactableObject)) continue;
            interactableObject.Selecet();

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactableObject.Interact();

                if (IsCarryingObject) continue;

                PickUpObject(col.gameObject);

            }
        }
    }

    private void PickUpObject(GameObject gameObject)
    {

        IsCarryingObject = true;

        _objectBeingCarried = gameObject;

        _rigidbodyOfCarriedObject = _objectBeingCarried.GetComponent<Rigidbody>();

        //_objectBeingCarried.GetComponent<Rigidbody>().isKinematic = true;

        _rigidbodyOfCarriedObject.isKinematic = true;

    }
}
