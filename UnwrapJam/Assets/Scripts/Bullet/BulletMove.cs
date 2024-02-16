
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 Dir
    {
        get => _dir;

        set
        {
            _dir = value;
            _dir = new(_dir.x, 0, _dir.z);
            _dir = _dir.normalized;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            _speed = Mathf.Abs(_speed);
        }
    }

    public bool WasParried { get; set; } = false;
    private Vector3 _dir;
    [SerializeField]private float _speed = 2f;


    private void OnEnable()
    {
        WasParried = false;
    }
    private void Awake()
    {
        Dir = transform.forward;
        WasParried = false;
    }
    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Dir;
    }

    public void Pary(Vector3 dir)
    {
        if (WasParried) return;
        Dir = dir;
        WasParried = true;
        AudioManager.instance.Play("Parry");
    }
}
