using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "DamageData")]
public class DamageData: ScriptableObject
{
    public int damage;
    public float pushPower;
    public Vector2 pushDegree;
    public float hitStunPower;
    public float launcherHorizontalForce;
    public float launcherVerticalForce;
    
    
}