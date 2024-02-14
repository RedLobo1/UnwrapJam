using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BigMechParryLogic : MonoBehaviour
{
    [SerializeField] private UnityEvent Parry;

    public SmallRobotControler PlayerInputMaster;

    private InputAction _perryAction;

    void Awake()
    {
        PlayerInputMaster = new SmallRobotControler();
    }

    private void OnEnable()
    {
        _perryAction = PlayerInputMaster.BigMechPlayer.Perry;

        //PlayerInputMaster.player.Enable();

        _perryAction.Enable();
    }

    private void OnDisable()
    {
        //PlayerInputMaster.player.Disable();
        _perryAction.Disable();
    }
    private void Update()
    {
        if (_perryAction.triggered)
        {
            Parry.Invoke();
            
        }
    }
}
