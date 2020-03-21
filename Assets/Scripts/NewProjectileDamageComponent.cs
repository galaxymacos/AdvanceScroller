using UnityEngine;

[RequireComponent(typeof(NewProjectile))]
public class NewProjectileDamageComponent: MonoBehaviour
{
    public CollisionDetector collisionDetector;

    public DamageData damageData;
    private PlayerCharacter owner;

    public bool isSingleDamage;
    private bool hasDealtDamage = false;

    private bool hasSetuped;
    
    private void Awake()
    {
        GetComponent<NewProjectile>().onProjectileSetupFinished += Setup;
        collisionDetector.onObjectCollided += DealDamageToCharacter;
    }

    private void Setup(NewProjectile.ProjectileArgument obj)
    {
        print("set up projectile damage component");
        owner = obj.owner;
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
                playerCharacter.GetComponent<DamageReceiver>().Analyze(damageData, transform);
                
                if (isSingleDamage)
                {
                    hasDealtDamage = true;
                }

            }

        }
    }
}