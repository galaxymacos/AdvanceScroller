using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHeroAnimatorEventHandler : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent attackFirstStrike;
    [SerializeField] private SingleAttackComponent attackSecondStrike;
    [SerializeField] private SingleAttackComponent bleedingAttack;

    [SerializeField] private ContinuousAttack lightningAttack;
    // private SingleAttackComponent attackFirstStrike;
    // private SingleAttackComponent attackFirstStrike;
    // Start is called before the first frame update
    public void ActivateAttackFirstStrikeHitBox()
    {
        attackFirstStrike.Execute();
    }

    public void ActivateAttackSecondStrikeHitBox()
    {
        attackSecondStrike.Execute();
    }

    public void ActivateBleedingAttackHitBox()
    {
        bleedingAttack.Execute();
    }
    
    public void ExecuteLightningAttack()
    {
        lightningAttack.Execute();
    }

    public void StopLightningAttack()
    { 
        lightningAttack.StopDetectTargetManually();
    }
}
