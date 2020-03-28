using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallDamageReceiver : MonoBehaviour, IDamageReceiver
{
    public NewProjectile tennisProjectile;

    public bool hasTakenDamage;

    public void Analyze(DamageData damageData, Transform damageOwner)
    {
        if (!hasTakenDamage)
        {

            tennisProjectile.Setup(damageOwner.gameObject, 50);
            hasTakenDamage = true;
        }
    }
}
