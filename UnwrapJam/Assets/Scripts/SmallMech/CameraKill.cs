
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigMech") || other.gameObject.CompareTag("SmallBoy"))
        {
            AudioManager.instance.StopAll();
            SceneManager.LoadScene("DeathScene");
        }
    }
}
