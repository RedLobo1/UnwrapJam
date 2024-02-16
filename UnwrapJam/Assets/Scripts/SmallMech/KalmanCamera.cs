
using UnityEngine;

public class KalmanCamera : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    public Transform BigMac;

    float smoothTime = 0.25f;

    Vector3 offset;

    Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - BigMac.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        Vector3 targetPos = BigMac.position + offset;



        Vector3 pos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        
    }
}
