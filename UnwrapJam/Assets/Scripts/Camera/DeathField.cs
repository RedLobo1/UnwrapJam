
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathField : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigMech"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
