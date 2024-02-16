
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/FireVelocityBuff")]
public class FireVelocityBuff : PowerUpAffects
{
    public float FireVelocityAdition = 0.3f;
    public override void Apply(GameObject target)
    {
        if (!target.TryGetComponent(out Parry parry)) return;
        parry.FireVelocityMultiplier += FireVelocityAdition;
    }
}
