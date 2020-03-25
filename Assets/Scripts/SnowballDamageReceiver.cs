using System;
using UnityEngine;

public class SnowballDamageReceiver: MonoBehaviour, IDamageReceiver
{
    [SerializeField] private Vector3 flyDirection = new Vector3(10f, 5f, 0.0f);

    [SerializeField] private float flySpeedGainPerDamage = 3f;
    private SnowballEventSystem snowballEventSystem;

    private void Awake()
    {
        snowballEventSystem = GetComponent<SnowballEventSystem>();
    }

    public class DamageReceiverArgs
    {
        public readonly DamageData damageData;
        public readonly Transform damageOwner;

        public DamageReceiverArgs(DamageData damageData, Transform damageOwner)
        {
            this.damageData = damageData;
            this.damageOwner = damageOwner;
        }
    }
    
    public void Analyze(DamageData damageData, Transform damageOwner)
    {

        var facingleft = damageOwner.position.x - transform.position.x > 0;
        flyDirection = facingleft
            ? new Vector3(-flyDirection.x, flyDirection.y, flyDirection.z)
            : flyDirection;
        flyDirection.Set((facingleft ? -flySpeedGainPerDamage : flySpeedGainPerDamage) * damageData.damage, flyDirection.y, flyDirection.z);
        var rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.AddForce(flyDirection);
        snowballEventSystem.SnowballTakeDamage(new DamageReceiverArgs(damageData, damageOwner));
    }
}

// this is a local event system