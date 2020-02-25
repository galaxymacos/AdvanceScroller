using System;
using UnityEngine;

public abstract class ChargeSkill: MonoBehaviour
{
    public float maxChargedTime;
    private float chargedTimeCounter;
    protected bool isChargingFinished;
    public PlayerCharacter owner;
    public bool isFacingRight;

    
    public void Setup(PlayerCharacter _owner)
    {
        owner = _owner;
        isFacingRight = _owner.isFacingRight;
    }

    public void StartCharging()
    {
        OnChargingStart();
        
    }

    public virtual void Update()
    {
        if (chargedTimeCounter < maxChargedTime)
        {
            chargedTimeCounter += Time.deltaTime;
            if (chargedTimeCounter >= maxChargedTime)
            {
                ChargeFull();
            }
        }
        

    }


    public void ReleaseCharging()
    {
        if (chargedTimeCounter >= maxChargedTime)
        {
            print("charging successes");
            ChargingSuccess();
        }
        else
        {
            print("charging failed");
            ChargingCancel();
        }
    }


    
    public void InteruptCharging()
    {
        OnChargingInterupt();
    }
    
    public void ChargingCancel()
    {
        OnChargingCancel();
    }

    private void ChargingSuccess()
    {
        
        OnChargingSuccess();
    }

    private void ChargeFull()
    {
        isChargingFinished = true;
        OnChargingFull();
    }

    protected abstract void OnChargingFull();

    protected abstract void OnChargingStart();
    protected abstract void OnChargingCancel();
    protected abstract void OnChargingInterupt();
    protected abstract void OnChargingSuccess();
    
}