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
    }

    protected override void OnChargingFull()
    {
    }

    protected override void OnChargingStart()
    {
    }

    protected override void OnChargingCancel()
    {
        print("throw small axe");
        GameObject axe = Instantiate(axePrefab, transform.position, Quaternion.identity);
        Projectile axeProjectile = axe.GetComponent<Projectile>();
        axeProjectile.Setup(owner,10,45);
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
        projectile.Setup(owner, 13, 0);
        
        enabled = false;
    }
}
