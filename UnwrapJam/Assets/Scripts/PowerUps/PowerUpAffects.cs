//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public abstract class PowerUpAffects : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
