using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/FireSpreadBuff")]
public class FireSpreadBuff : PowerUpAffects
{
    public float FireSpreadReduction = 5;
    public override void Apply(GameObject target)
    {
        if (!target.TryGetComponent(out Parry parry)) return;
        parry.ParrySpread -= FireSpreadReduction;
    }
}
