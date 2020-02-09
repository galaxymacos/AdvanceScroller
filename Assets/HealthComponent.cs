using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public int health = 100;

    private Animator animator;
    private static readonly int Die = Animator.StringToHash("die");

    
    private bool isTimeFreezed;
    private float freezeTimeCounter;
    private float maxBulletTime = 0.4f;
    private float bulletTime;

    private CameraShake cameraShake;

    public FloatAction onHealthChanged;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (Camera.main != null) cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void Update()
    {
    }

    // Start is called before the first frame update
    public void TakeDamage(int amount, bool canTimeFreezed = true)
    {
        health = Mathf.Clamp(health-amount, 0, 100);
        if (health == 0)
        {
            animator.SetTrigger(Die);
        }

        float percentage = (float) amount / health;
        float strength = Mathf.Clamp01(percentage);

        StartCoroutine(cameraShake.Shake(.15f, .1f));

        bulletTime = maxBulletTime * strength;
        
        if (canTimeFreezed)
        {
            BulletTimeManager.instance.Register(bulletTime);
        }

        onHealthChanged?.Invoke(health);

    }

    public void HitFreeze()
    {
        Time.timeScale = 0.01f;
        isTimeFreezed = true;
    }
    
    public void Heal(int amount)
    {
        health = Mathf.Clamp(health+amount, 0, 100);
        onHealthChanged?.Invoke(health);
    }
}

[Serializable]
public class FloatAction : UnityEvent<float>
{
    
}