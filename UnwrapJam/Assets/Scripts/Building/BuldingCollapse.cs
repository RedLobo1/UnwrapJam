using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldingCollapse : MonoBehaviour, IDestructible
{

    Animator animator;
    ParticleSystem _ps;

    [SerializeField]GameObject rubble;

    bool _isDestroyed;

    [SerializeField] GameObject _prefabToDrop;


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
        Destroy(this.gameObject);
        GameObject newRubble = Instantiate(rubble);
        newRubble.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        if (_prefabToDrop != null) Instantiate(_prefabToDrop, this.transform.position+Vector3.up, Quaternion.identity);


    }
}
