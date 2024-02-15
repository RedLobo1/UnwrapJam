using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigMech"))
        {
            SceneManager.LoadScene("DeathScene");
        }

        if (other.gameObject.CompareTag("SmallBoy"))
        {
            Debug.Log("SmallBoyDead");
        }
    }
}