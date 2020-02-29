using System;
using UnityEngine;

public abstract class ChargeSkill : MonoBehaviour
{
    public float maxChargedTime;
    private float chargedTimeCounter;
    protected bool isChargingFinished;
    public PlayerCharacter owner;
    public bool isFacingRight;
    public bool hasReleased;
    public GameObject chargeVFXPrefab;
    private GameObject chargeVFX;


    public void Setup(PlayerCharacter _owner)
    {
        owner = _owner;
        isFacingRight = _owner.isFacingRight;
    }

    public void StartCharging()
    {
        chargeVFX = Instantiate(chargeVFXPrefab, owner.transform.position, Quaternion.identity);
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
        Tick();
    }

    public abstract void Tick();


    public void ReleaseCharging()
    {
        if (hasReleased) return;
        hasReleased = true;
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
        if (chargeVFX != null)
        {
            Destroy(chargeVFX);
        }
        OnChargingInterupt();
    }

    public void ChargingCancel()
    {
        if (chargeVFX != null)
        {
            Destroy(chargeVFX);
        }

        OnChargingCancel();
    }

    private void ChargingSuccess()
    {
        if (chargeVFX != null)
        {
            Destroy(chargeVFX);
        }
        OnChargingSuccess();
    }

    private void ChargeFull()
    {
        if (chargeVFX != null)
        {
            Destroy(chargeVFX);
        }
        isChargingFinished = true;
        OnChargingFull();
    }

    protected abstract void OnChargingFull();

    protected abstract void OnChargingStart();
    protected abstract void OnChargingCancel();
    protected abstract void OnChargingInterupt();
    protected abstract void OnChargingSuccess();
}