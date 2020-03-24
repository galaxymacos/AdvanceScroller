using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticleSpawner : MonoBehaviour
{
    private float bloodParticleOffset = 0.5f;

    private void Awake()
    {
        GetComponent<CharacterHealthComponent>().onTakeHit += SpawnBlood;
    }

    public void SpawnBlood(CharacterHealthComponent characterHealthComponent)
    {
        Transform damageSource = characterHealthComponent.damageSourceFromLastAttack;
        Transform bloodOwner = characterHealthComponent.transform;
        Vector3 bloodStartRotation = Vector3.Normalize(bloodOwner.position - damageSource.position);
        GameObject bloodParticleSystem;
        switch (characterHealthComponent.damageDataFromLastAttack.damageType)
        {
            case DamageType.Penetration:
                bloodParticleSystem = Instantiate(ParticleSpawner.Instance.BloodSplatDirectional2D,
                    transform.position + bloodStartRotation * bloodParticleOffset,
                    Quaternion.identity);
                
                break;
            case DamageType.ShotGun:
                bloodParticleSystem = Instantiate(ParticleSpawner.Instance.BloodSplatCritcal2D,
                    transform.position + bloodStartRotation * bloodParticleOffset,
                    Quaternion.identity);
                
                break;
            case DamageType.Explosion:
                bloodParticleSystem = Instantiate(ParticleSpawner.Instance.BloodExplosion2D, transform.position,
                    Quaternion.identity);
                
                break;
            case DamageType.HorizontalDripping:
                bloodParticleSystem = Instantiate(ParticleSpawner.Instance.BloodShowerLoop2D,
                    transform.position + bloodStartRotation * bloodParticleOffset,
                    Quaternion.identity);
                
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


        bloodParticleSystem.GetComponent<CharacterBloodType>()?.Setup(damageSource, bloodOwner);

    }

    public void SpawnBloodDrippingParticle(float duration)
    {
        GameObject bloodParticleSystem = Instantiate(ParticleSpawner.Instance.BloodDripping2D, transform);
        Destroy(bloodParticleSystem, duration);

    }

    


}