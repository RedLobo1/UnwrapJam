
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnDisable()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
