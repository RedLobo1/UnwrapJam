
using UnityEngine;

public class RobotSoundLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("HeavySteps");
        AudioManager.instance.Play("SteamSound");
        AudioManager.instance.Play("EngineRunning");
        AudioManager.instance.Play("CityAmbience");
        AudioManager.instance.Play("TankAmbience");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        { 
            AudioManager.instance.Play("Parry"); 
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.Play("Hit");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManager.instance.Play("Whoosh");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.Play("Upgrade");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AudioManager.instance.Play("ScrapCollected");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.instance.Play("TankProjectileHit");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.Play("TankDie");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.instance.Play("TankShoot");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioManager.instance.Play("LittleGuyPickup");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            AudioManager.instance.Play("LittleGuyThrow");
        }
    }
}
