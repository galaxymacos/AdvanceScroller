using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCharacter))]
public class CharacterHealthComponent : MonoBehaviour
{
    public float maxHealth = 260;
    public float currentHealth;
    private float healthWas;



    private float maxBulletTime = 0.4f;
    private float bulletTime;
    private CameraShake cameraShake;
    public bool isPlayerDead => currentHealth <= 0;


    public event Action<CharacterHealthComponent> onTakeHit; // Call if the 
    public event Action<CharacterHealthComponent> onLoseHealth;    // Call if the health value decreases
    public event Action<CharacterHealthComponent> onHealthChanged;    // Call if the health value change
    public static event Action<CharacterHealthComponent> onPlayerDie;

    // private CharacterBleedingComponent bleedingComponent;
    
    // Store the information of the last attack
    
    [HideInInspector] public Transform damageSourceFromLastAttack;
    [HideInInspector] public DamageData damageDataFromLastAttack;

    private void Awake()
    {
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
        if (currentHealth - healthWas < -Mathf.Epsilon)
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

        float percentage = _damageData.damage / maxHealth;

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
        
        currentHealth = Mathf.Clamp(currentHealth-drain, 0, maxHealth);
        if (Math.Abs(currentHealth) <=0)
        {
            onPlayerDie?.Invoke(this);
        }

    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth+amount, 0, maxHealth);
    }

    
}


[Serializable]
public class FloatAction : UnityEvent<float>
{
    
}