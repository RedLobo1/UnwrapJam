using System.Collections;
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

    [SerializeField] Collider parryCollider;

    public bool _onCooldown;
    public float _cooldownLength = 5;

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
            if (_onCooldown) 
            {
                AudioManager.instance.Play("Buzzer");
                return;
                
            }
            Debug.Log("Front");
            AudioManager.instance.Play("Whoosh");
            ParryFront.Invoke();
            StartCoroutine(RunCooldown());
        }

        if (_parryActionSwipe.triggered)
        {
            Debug.Log("Swipe");
            ParrySwipe.Invoke();
        }
    }

    private IEnumerator RunCooldown()
    {
        parryCollider.enabled = true;
        SideColours.instance.ChangeParryingColour(true);

        _onCooldown = true;
        yield return new WaitForSeconds(_cooldownLength);
        _onCooldown = false;
        SideColours.instance.ChangeParryingColour(false);
        parryCollider.enabled = false;

    }
}
