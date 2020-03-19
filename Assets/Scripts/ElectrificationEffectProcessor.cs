using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElectrificationEffectProcessor : MonoBehaviour, IAttackEffectProcessor
{
    public CharacterHealthComponent healthComponent;
    private float duration;
    private float odd;
    [SerializeField] private float delay = 0.2f;
    public bool isElectrification => duration > 0;

    private void Awake()
    {
        healthComponent = GetComponentInParent<CharacterHealthComponent>();
        healthComponent.onTakeHit += ProcessBridge;
        healthComponent.onTakeHit += ApplyElectricityDamage;
    }

    private void ProcessBridge(CharacterHealthComponent health)
    {
        Process(health.damageDataFromLastAttack);
    }


    public void Process(DamageData damageData)
    {
        if (damageData.attackEffects == null) return;
        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var electrificationEffect = attackEffect as ElectrificationEffect;
            if (electrificationEffect != null)
            {
                duration = electrificationEffect.duration;
                odd = electrificationEffect.ElectrificationOdd;
            }
        }
    }

    private void ApplyElectricityDamage(CharacterHealthComponent characterHealthComponent)
    {
        if (isElectrification)
        {
            StartCoroutine(GanDian(delay));
        }
    }

    private IEnumerator GanDian(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        ElectrificationTick();
    }

    private void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
    }


    private void ElectrificationTick()
    {
        bool success = Random.Range(0, 100) > odd * 100;
        if (success)
        {
            ElectricShot();
        }
    }

    private void ElectricShot()
    {
        healthComponent.DrainHealth(10);
        SpriteEffectFactory.instance.SpawnEffect("Electricity Explosion", transform.root);
        print("ElectricShot");
    }
    
}