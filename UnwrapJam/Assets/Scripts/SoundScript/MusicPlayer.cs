using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]AudioSource music;

    private void Start()
    {
        music.Play();
    }
}
