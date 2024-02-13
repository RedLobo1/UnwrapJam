using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSoundLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("HeavySteps");
        AudioManager.instance.Play("SteamSound");
        AudioManager.instance.Play("EngineRunning");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        { 
            AudioManager.instance.Play("Parry"); 
        }
    }
}
