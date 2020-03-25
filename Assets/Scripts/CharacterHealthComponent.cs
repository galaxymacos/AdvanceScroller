using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCharacter))]
public class CharacterHealthComponent : MonoBehaviour
{
    public float maxHealth = 100;
    [HideInInspector] public float currentHealth;
    private float healthWas;

    private Animator animator;
    private static readonly int Die = Animator.StringToHash("die");

    
    private bool isTimeFreezed;
    private float freezeTimeCounter;
    private float maxBulletTime = 0.4f;
    private float bulletTime;
    private CameraShake cameraShake;
    public bool isPlayerDead => currentHealth <= 0;


    public event Action<CharacterHealthComponent> onTakeHit;
    public Action<CharacterHealthComponent> onLoseHealth;
    public Action<CharacterHealthComponent> onHealthChanged;
    public Action onPlayerDie;

    // private CharacterBleedingComponent bleedingComponent;
    
    // Store the information of the last attack
    
    [HideInInspector] public Transform damageSourceFromLastAttack;
    [HideInInspector] public DamageData damageDataFromLastAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (Camera.main != null) cameraShake = Camera.main.GetComponent<CameraShake>();
        GetComponent<PlayerCharacter>();
        currentHealth = maxHealth;
        healthWas = currentHealth;
        // bleedingComponent = new CharacterBleedingComponent(this);
    }

    private void Update()
    {
        if (Math.Abs(currentHealth - healthWas) > Mathf.Epsilon)
        {
            onHealthChanged?.Invoke(this);
        }
        if (Math.Abs(currentHealth - healthWas) < -Mathf.Epsilon)
        {
            onLoseHealth?.Invoke(this);
        }
        
        
        healthWas = currentHealth;

    }

    // Start is called before the first frame update
    public void TakeDamage(DamageData _damageData, Transform _damageSource, bool canTimeFreezed)
    {
        damageSourceFromLastAttack = _damageSource;
        damageDataFromLastAttack = _damageData;
        // bleedingComponent.CheckBleed(_damageData);
        // if (playerCharacter.dashInvincibleTimeCounter > 0)
        // {
        //     playerCharacter.onPlayerDodgeDamage?.Invoke();
        // }
        
        DrainHealth(_damageData.damage);

        float percentage = (float) _damageData.damage / maxHealth;

        float strength = Mathf.Clamp01(percentage);

        StartCoroutine(cameraShake.Shake(.15f, .1f));

        bulletTime = maxBulletTime * strength;
        
        if (canTimeFreezed)
        {
            BulletTimeManager.instance.Register(bulletTime);
        }
        
        onTakeHit?.Invoke(this);

        
        
    }

    public void DrainHealth(float drain)
    {
        
        currentHealth = Mathf.Clamp(currentHealth-drain, 0, 100);
        if (Math.Abs(currentHealth) <=0)
        {
            onPlayerDie?.Invoke();
        }

    }


    // public void HitFreeze()
    // {
    //     Time.timeScale = 0.01f;
    //     isTimeFreezed = true;
    // }
    
    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth+amount, 0, maxHealth);
    }

    
}

// public class CharacterBleedingComponent
// {
//     private readonly CharacterHealthComponent healthComponent;
//     private float bleedTimeCounter;
//     private float bleedPerSecond;
//     public bool isBleeding => bleedTimeCounter > 0;
//
//     public CharacterBleedingComponent(CharacterHealthComponent healthComponent)
//     {
//         this.healthComponent = healthComponent;
//     }
//
//     public void CheckBleed(DamageData damageData)
//     {
//         if (damageData.canBleed)
//         {
//             bleedTimeCounter = damageData.bleedTime;
//             bleedPerSecond = damageData.bleedAmountPerSecond;
//         }
//     }
//     
//     public void Update()
//     {
//         if (isBleeding)
//         {
//             bleedTimeCounter-=Time.deltaTime;
//             healthComponent.DrainHealth(bleedPerSecond*Time.deltaTime);
//         }
//     }
// }


[Serializable]
public class FloatAction : UnityEvent<float>
{
    
}