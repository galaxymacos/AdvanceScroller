using System;
using UnityEngine;

public class NewProjectileDamageComponent: MonoBehaviour
{
    public CollisionDetector collisionDetector;

    public DamageData damageData;
    public GameObject owner;

    public bool isSingleDamage;  
    private bool hasDealtDamage = false;
    public bool Expired { get; set; }

    public event Action onDamageDealt;
    private bool hasSetuped;
    public DetectionMethod detectionMethod;
    public enum DetectionMethod {Trigger,Collision}

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
        if(hasSetuped) 
        print("setup damage component");
        owner = obj.owner;
        hasSetuped = true;
    }
    
    
    public void Setup(GameObject _owner)
    {
        print("setup damage component");
        owner = _owner;
        hasSetuped = true;
    }



    

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (detectionMethod == DetectionMethod.Collision)
        {
            if (!hasSetuped || Expired) return;
            print("Collide with "+other.gameObject.name);


            if (other.gameObject.GetComponent<IDamageReceiver>() != null &&
                other.gameObject != owner)
            {
                if (isSingleDamage && !hasDealtDamage || !isSingleDamage)
                {
                    print("take damage");
                    other.gameObject.GetComponent<IDamageReceiver>().Analyze(damageData, transform);
                    onDamageDealt?.Invoke();
                
                    if (isSingleDamage)
                    {
                        hasDealtDamage = true;
                    }

                }

            }
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (detectionMethod == DetectionMethod.Trigger)
        {
            if (!hasSetuped || Expired) return;
            print("Collide with "+other.gameObject.name);


            if (other.gameObject.GetComponent<IDamageReceiver>() != null &&
                other.gameObject != owner)
            {
                if (isSingleDamage && !hasDealtDamage || !isSingleDamage)
                {
                    print("take damage");
                    other.gameObject.GetComponent<IDamageReceiver>().Analyze(damageData, transform);
                    onDamageDealt?.Invoke();
                
                    if (isSingleDamage)
                    {
                        hasDealtDamage = true;
                    }

                }

            }
        }
        
    }
}