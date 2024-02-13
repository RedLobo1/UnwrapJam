using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpProt : MonoBehaviour,IPickUpAble
{
    public void Interact()
    {
        Debug.Log("Interacted");
    }

    public void Selecet()
    {
        Debug.Log("Selected");
    }

    
}
