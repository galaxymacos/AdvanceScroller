using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedAxe : ChargeSkill
{
    [SerializeField] private Projectile projectile;

    public GameObject axePrefab;

    private void OnValidate()
    {
        projectile = GetComponent<Projectile>();
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnChargingFull()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnChargingStart()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnChargingCancel()
    {
        GameObject axe = Instantiate(axePrefab, transform.position, Quaternion.identity);
        Projectile axeProjectile = axe.GetComponent<Projectile>();
        axeProjectile.Setup(owner);
        GetComponent<Projectile>().destroyWithoutDeadEffect = true;
        Destroy(gameObject);
    }

    protected override void OnChargingInterupt()
    {
        Destroy(gameObject);
    }

    protected override void OnChargingSuccess()
    {
        projectile = GetComponent<Projectile>();
        projectile.Setup(owner, 100, 0);
        
        enabled = false;
    }
}
