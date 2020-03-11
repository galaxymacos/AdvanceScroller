using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "DamageData")]
public class DamageData: ScriptableObject
{

    public int damage;
    
    
    public float pushPower;
    public float pushDistance;
    public PushType pushType;
    public DamageType damageType;
    
    
    public float offSetDegree;
    public float hitStunPower;
    public float launcherHorizontalForce;
    public float launcherVerticalForce;

    public List<ScriptableObject> attackEffects;


}

public enum PushType
{
    AccordingToRelativePosition, SpecificAngleOnly
}

public enum DamageType
{
    Penetration, ShotGun, Explosion, Dripping, HorizontalDripping
}