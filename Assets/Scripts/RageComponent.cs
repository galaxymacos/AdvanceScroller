using System;
using UnityEngine;

public class RageComponent: MonoBehaviour
{
    [SerializeField] private int _maxRage = 100;

    private CharacterHealthComponent health;
    private PlayerCharacter player;

    public readonly string ultimateSkillName = "skill4";
    
    public int MaxRage => _maxRage;

    public int CurrentRage => _currentRage;

    private int _currentRage;
    public bool canUseUltimate => _currentRage == _maxRage;
    public float GetRagePercentage => (float) _currentRage / _maxRage;

    private void Awake()
    {
        health = GetComponent<CharacterHealthComponent>();
        health.OnTakeHit += IncreaseRageFromTakingDamage;
        player = GetComponent<PlayerCharacter>();
        player.onPlayerUseUltimate += ConsumeRage;

        _currentRage = MaxRage;

    }

    // Take damage to increase rage
    public void IncreaseRageFromTakingDamage(CharacterHealthComponent characterHealthComponent)
    {
        if (characterHealthComponent.damageDataFromLastAttack != null)
        {
            _currentRage = Mathf.Clamp(_currentRage + characterHealthComponent.damageDataFromLastAttack.damage * 2, 0, _maxRage);
        } 
    }
    
    
    
    public void ConsumeRage()
    {
        _currentRage = 0;
    }
}