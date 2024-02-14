using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BigMechParryLogic : MonoBehaviour
{
    [SerializeField] private UnityEvent ParryFront;
    [SerializeField] private UnityEvent ParrySwipe;

    public SmallRobotControler PlayerInputMaster;

    private InputAction _parryActionFront;
    private InputAction _parryActionSwipe;

    void Awake()
    {
        PlayerInputMaster = new SmallRobotControler();
    }

    private void OnEnable()
    {
        _parryActionFront = PlayerInputMaster.BigMechPlayer.Perry;
        _parryActionSwipe = PlayerInputMaster.BigMechPlayer.ArcParry;

        //PlayerInputMaster.player.Enable();

        _parryActionFront.Enable();
        _parryActionSwipe.Enable();
    }

    private void OnDisable()
    {
        //PlayerInputMaster.player.Disable();
        _parryActionFront.Disable();
        _parryActionSwipe.Disable();
    }
    private void Update()
    {
        if (_parryActionFront.triggered)
        {
            Debug.Log("Front");
            ParryFront.Invoke();
        }

        if (_parryActionSwipe.triggered)
        {
            Debug.Log("Swipe");
            ParrySwipe.Invoke();
        }
    }

    public void FindDestructiblesOnParry()
    {

    }
}
