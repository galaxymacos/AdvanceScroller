using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "DamageData")]
public class DamageData: ScriptableObject
{
    public int damage;
    public float pushPower;
    public PushType pushType;
    public float offSetDegree;
    public float hitStunPower;
    public float launcherHorizontalForce;
    public float launcherVerticalForce;
    
    
}

public enum PushType
{
    AccordingToRelativePosition, SpecificAngleOnly
}