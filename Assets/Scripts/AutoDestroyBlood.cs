using UnityEngine;

public class AutoDestroyBlood : CharacterBloodType
{
    public override void Setup(Transform damageSource, Transform bloodOwner)
    {
        var bloodParticleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (var bps in bloodParticleSystems)
        {
            var collision = bps.collision;
            collision.collidesWith = ~0;
            var layerToIgnore = bloodOwner.root.gameObject.layer;
            collision.collidesWith = ~((1 << layerToIgnore) | (1 << gameObject.layer));

        }
        Destroy(gameObject, duration);
    }
}