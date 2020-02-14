using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHeroAttackModifier : MonoBehaviour
{
    
    public SingleAttackComponent attack;
    public SingleAttackComponent hugeSlash;
    public DamageData attackDamageDataRed;
    public DamageData attackDamageDataGreen;
    public DamageData hugeSlashDamageRed;
    public DamageData hugeSlashDamageGreen;

    public void TransformToRedStage()
    {
        print("transform to red stage");
        attack.damageData = attackDamageDataRed;
        hugeSlash.damageData = hugeSlashDamageRed;
    }

    public void TransformToGreenStage()
    {
        print("transform to green stage");
        attack.damageData = attackDamageDataGreen;
        hugeSlash.damageData = hugeSlashDamageGreen;
    }
}
