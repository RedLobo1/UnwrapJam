using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpAffects
{
    public float amount;

    public override void Apply(GameObject target)
    {
        if(!target.TryGetComponent(out MechHealth mechHealth)) return;
        mechHealth.Heal(amount);
    }
}
