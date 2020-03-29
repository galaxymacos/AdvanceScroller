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


    [SerializeField] private DamageData shadowDamageData;

    // private SingleAttackComponent attackFirstStrike;
    // private SingleAttackComponent attackFirstStrike;
    // Start is called before the first frame update
    public void ActivateAttackFirstStrikeHitBox()
    {
        if (GetComponent<UltimateBuffTimer>().InUltimateStage)
        {
            StartCoroutine(AttackFirstStrikeShadowVersion(attackFirstStrike));
        }
        else
        {
            attackFirstStrike.Execute();
        }

    }

    private IEnumerator AttackFirstStrikeShadowVersion(SingleAttackComponent singleAttackComponent)
    {
        var temp = singleAttackComponent.damageData;
        singleAttackComponent.damageData = shadowDamageData;

        for (int i = 0; i < GetComponents<ShadowSpritesStorer>().Length; i++)
        {
            singleAttackComponent.Execute();
            yield return new WaitForSeconds(0.09f);
        }

        singleAttackComponent.damageData = temp;
        singleAttackComponent.Execute();
    }

    public void ActivateAttackSecondStrikeHitBox()
    {
        if (GetComponent<UltimateBuffTimer>().InUltimateStage)
        {
            StartCoroutine(AttackFirstStrikeShadowVersion(attackSecondStrike));
        }
        else
        {
            attackSecondStrike.Execute();
        }
    }

    public void ActivateBleedingAttackHitBox()
    {
        if (GetComponent<UltimateBuffTimer>().InUltimateStage)
        {
            StartCoroutine(AttackFirstStrikeShadowVersion(bleedingAttack));
        }
        else
        {
            bleedingAttack.Execute();
        }
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