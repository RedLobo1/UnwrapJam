
using System;
using UnityEngine;

public partial class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.root.gameObject);

        foreach (Sound s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.Source.Play();
    }

    public void Stop(string name)
    {
        StopSoundByName(name);
    }

    private void StopSoundByName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        if (s != null)
        {
            s?.Source?.Stop();
        }
        else
        {
            Debug.LogWarning("Sound: " + name + " not found");
        }
    }

    public void StopAll()
    {
        foreach (var sound in sounds)
        {
            if (sound.Name == "Theme") continue;
            StopSoundByName(sound.Name);
        }
    }
}

