using System;
using UnityEngine;

public class NewProjectileDamageComponent: MonoBehaviour
{
    public CollisionDetector collisionDetector;

    public DamageData damageData;
    private PlayerCharacter owner;

    public bool isSingleDamage;
    private bool hasDealtDamage = false;
    public event Action onDamageDealt;
    private bool hasSetuped;
    
    private void Awake()
    {
        if (GetComponent<NewProjectile>() != null)
        {
            GetComponent<NewProjectile>().onProjectileSetupFinished += Setup;
        }
        collisionDetector.onObjectCollided += DealDamageToCharacter;
    }

    private void Setup(NewProjectile.ProjectileArgument obj)
    {
        if (hasSetuped) return;
        
        print("set up projectile damage component");
        owner = obj.owner;
        hasSetuped = true;
    }
    
    
    public void Setup(PlayerCharacter _owner)
    {
        if (hasSetuped) return;
        print("set up projectile damage component");
        this.owner = _owner;
        hasSetuped = true;
    }

    private void DealDamageToCharacter(GameObject playerCharacter)
    {
        if (!hasSetuped) return;
        
        
        if (playerCharacter.GetComponent<CharacterHealthComponent>() != null &&
            playerCharacter.GetComponent<PlayerCharacter>() != owner)
        {
            if ((isSingleDamage && !hasDealtDamage) || !isSingleDamage)
            {
                print("take damage");
                playerCharacter.GetComponent<IDamageReceiver>().Analyze(damageData, transform);
                onDamageDealt?.Invoke();
                
                if (isSingleDamage)
                {
                    hasDealtDamage = true;
                }

            }

        }
    }
}