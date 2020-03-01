using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // private CollisionDetector collisionDetector;
    [SerializeField] private DamageData damageData;

    [Tooltip("If the interval counter is greater than 0, then the spike does not hit player")] [SerializeField]
    private float interval = 0.6f;
    public Dictionary<DamageReceiver, float> playersTakeDamage;

    private void Awake()
    {
        playersTakeDamage = new Dictionary<DamageReceiver, float>();
    }

    private void Update()
    {
        List<DamageReceiver> keys = new List<DamageReceiver>(playersTakeDamage.Keys);
        foreach (DamageReceiver damageReceiver in keys)
        {
            if (playersTakeDamage[damageReceiver] > 0)
            {
                playersTakeDamage[damageReceiver] = playersTakeDamage[damageReceiver] - Time.deltaTime;
            }
            else
            {
                playersTakeDamage.Remove(damageReceiver);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver != null)
        {
            if (!playersTakeDamage.ContainsKey(damageReceiver))
            {
                damageReceiver.Analyze(damageData, transform);
                playersTakeDamage.Add(damageReceiver, interval);
            }
        }
    }
}