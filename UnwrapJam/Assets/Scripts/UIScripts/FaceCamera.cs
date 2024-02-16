
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
   Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = cam.transform.rotation;
    }
}
