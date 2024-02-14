using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSlider : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] MechHealth mech;
    [SerializeField] GameObject _fillArea;

    public void Start()
    {
        _slider = GetComponentInParent<Slider>();




    }

    public void Update()
    {
        _slider.maxValue = mech._maxHealth;
        _slider.value = mech.CurrentHealth;

        if (_slider.value <= 0)
        {
            _fillArea.SetActive(false);
        }
        else
        {
            _fillArea.SetActive(true);
        }



    }



}


