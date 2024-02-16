
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SplitBuff")]
public class SplitBuff : PowerUpAffects
{
    public int SplitAdition = 1;
    public override void Apply(GameObject target)
    {
        if (!target.TryGetComponent(out Parry parry)) return;
        parry.SplitCount += SplitAdition;
    }
}
