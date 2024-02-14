using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldingCollapse : MonoBehaviour, IDestructible
{

    Animator animator;
    ParticleSystem _ps;
    MeshRenderer _renderer;

    bool _isDestroyed;


    private void Awake()
    {

        animator = GetComponentInChildren<Animator>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _ps.Stop();
    }
    public void Destruct()
    {
        if (!_isDestroyed)
        {
            _isDestroyed = true;
            StartCoroutine(Collapse());
        }
    }

    private IEnumerator Collapse()
    {
        animator.Play("buildingCollapse");
        _ps.Play();
        yield return new WaitForSeconds(1.5f);
        _ps.Stop();
        //changeToRubbleMeshRenderer    

    }
}
