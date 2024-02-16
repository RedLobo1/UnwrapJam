using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedBuff")]
public class SpeedBuff : PowerUpAffects
{
    public float SpeedMultiplier = 1f;
    public float BuffDuratiohn = 1;
    public override void Apply(GameObject target)
    {
        if (!target.TryGetComponent(out BigMechMovement bigMechMovement)) return;
        CoroutineRunner.Runner.StartCoroutine(ApplySpeedBuff(bigMechMovement));
    }

    private IEnumerator ApplySpeedBuff(BigMechMovement bigMechMovement)
    {
        float baseSpeed = bigMechMovement.Speed;
        bigMechMovement.Speed = baseSpeed * SpeedMultiplier;

        yield return new WaitForSeconds(BuffDuratiohn);
        bigMechMovement.Speed = baseSpeed;
    }
}
