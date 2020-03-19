using System;
using UnityEngine;

public class RageComponent: MonoBehaviour
{
    [SerializeField] private int _maxRage = 100;

    private CharacterHealthComponent health;
    private PlayerCharacter player;

    public readonly string ultimateSkillName = "skill4";
    
    public float MaxRage => _maxRage;

    public float CurrentRage => _currentRage;

    private float _currentRage;
    public bool canUseUltimate => Math.Abs(_currentRage - _maxRage) < Mathf.Epsilon;
    public float GetRagePercentage => _currentRage / _maxRage;

    public Action onRageChanged;
    private float rageWas;
    
    private void Awake()
    {
        health = GetComponent<CharacterHealthComponent>();
        health.onTakeHit += IncreaseRageFromTakingDamage;
        player = GetComponent<PlayerCharacter>();
        player.onPlayerUseUltimate += ConsumeRage;

        _currentRage = MaxRage;

        
    }

    private void Update()
    {
        if (Math.Abs(_currentRage - rageWas) > Mathf.Epsilon)
        {
            onRageChanged?.Invoke();
        }
        
        rageWas = _currentRage;
    }

    // Take damage to increase rage
    public void IncreaseRageFromTakingDamage(CharacterHealthComponent characterHealthComponent)
    {
        if (characterHealthComponent.damageDataFromLastAttack != null)
        {
            _currentRage = Mathf.Clamp(_currentRage + characterHealthComponent.damageDataFromLastAttack.damage * 2, 0, _maxRage);
        } 
    }


    public void RecoverRage(float amount)
    {
        _currentRage = Mathf.Clamp(_currentRage + amount, 0, _maxRage);
    }
    public void ConsumeRage()
    {
        _currentRage = 0;
    }
}