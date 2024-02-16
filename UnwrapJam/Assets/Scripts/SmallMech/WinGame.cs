
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnDisable()
    {
        AudioManager.instance.StopAll();
        SceneManager.LoadScene(4);
    }
}
