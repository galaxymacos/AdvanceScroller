using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHeroAnimatorEventHandler : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent attackFirstStrike;
    [SerializeField] private SingleAttackComponent attackSecondStrike;
    [SerializeField] private SingleAttackComponent bleedingAttack;
    [SerializeField] private ContinuousAttack lightningAttack;

    [SerializeField] private GameObject catPrefab;
    [SerializeField] private Transform catSpawnLocation;
    
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

    public void SpawnCat()
    {
        var cat = Instantiate(catPrefab, transform.position, Quaternion.identity);
        Cat catScript = cat.GetComponent<Cat>();
        catScript.Setup(transform.GetComponent<PlayerCharacter>());
    }
}
