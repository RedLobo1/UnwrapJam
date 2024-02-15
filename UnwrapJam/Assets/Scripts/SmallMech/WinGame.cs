using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnDisable()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
