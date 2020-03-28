using System;
using UnityEngine;

public class NewProjectileDamageComponent: MonoBehaviour
{
    public CollisionDetector collisionDetector;

    public DamageData damageData;
    public GameObject owner;

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
    }

    private void OnDestroy()
    {
        if (GetComponent<NewProjectile>() != null)
        {
            GetComponent<NewProjectile>().onProjectileSetupFinished -= Setup;
        }
    }

    private void Setup(NewProjectile.ProjectileArgument obj)
    {
        if (hasSetuped) return;
        
        owner = obj.owner;
        hasSetuped = true;
    }
    
    
    public void Setup(GameObject _owner)
    {
        if (hasSetuped) return;
        print("set up projectile damage component");
        owner = _owner;
        hasSetuped = true;
    }



    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSetuped) return;
        
        
        if (other.GetComponent<IDamageReceiver>() != null &&
            other.gameObject != owner)
        {
            if ((isSingleDamage && !hasDealtDamage) || !isSingleDamage)
            {
                print("take damage");
                other.GetComponent<IDamageReceiver>().Analyze(damageData, transform);
                onDamageDealt?.Invoke();
                
                if (isSingleDamage)
                {
                    hasDealtDamage = true;
                }

            }

        }
    }
}