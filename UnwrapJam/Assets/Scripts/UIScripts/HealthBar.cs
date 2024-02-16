
using UnityEngine;
using UnityEngine.UI;

public class healthSlider : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] MechHealth mech;
    [SerializeField] GameObject _fillArea;

    public void Start()
    {
        _slider = GetComponentInChildren<Slider>();




    }

    public void Update()
    {
        
        _slider.value = mech.CurrentHealth/mech._maxHealth;

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


