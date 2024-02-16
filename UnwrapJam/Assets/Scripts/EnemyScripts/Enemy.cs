
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDestructible
{
    public UnityEvent Shoot;

    [SerializeField] float damage;
    [SerializeField] int maxHealth = 100;
    [SerializeField] float currentHealth;

    [SerializeField] public float _shootingRange = 2;
    [SerializeField] public float _shootingCooldown = 3f;
    private GameObject _target;

    bool _enemyInRange = false;
    bool _isShooting = false;

    [SerializeField]ParticleSystem _explosion;


    

    private void OnEnable()
    {
        currentHealth = maxHealth;
        _explosion.Stop();
    }

    private void Update()
    {
        if(_target!=null && Vector3.Distance(this.transform.position, _target.transform.position)<=_shootingRange)
        {           

            _enemyInRange = true;
        }
        else _enemyInRange = false;

        if(_enemyInRange==true && _isShooting==false)
        {
            StartCoroutine(ShootCountdown());
            _isShooting = true;
        }
        if(_target!=null)
        this.transform.LookAt(_target.transform);
    }

    private IEnumerator ShootCountdown()
    {
        yield return new WaitForSeconds(_shootingCooldown);
        Debug.Log("Shot Fired");
        Shoot?.Invoke();
        AudioManager.instance.Play("TankShoot");
        _isShooting = false;
    }

    public void SetTarget(GameObject go)
    {
        _target = go;
    }

    public IEnumerator Die()
    {
        _explosion.Play();
        AudioManager.instance.Play("TankDie");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }

  

    void IDestructible.Destruct()
    {
        StartCoroutine(Die());
    }
}
