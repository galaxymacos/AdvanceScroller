using UnityEngine;

public abstract class CharacterBloodType : MonoBehaviour
{
    [SerializeField] protected float duration = 2f;

    public virtual void Setup(Transform damageSource, Transform bloodOwner)
    {
        var bloodParticleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (var bps in bloodParticleSystems)
        {
            var collision = bps.collision;
            collision.collidesWith = ~0;
            var layerToIgnore = bloodOwner.root.gameObject.layer;
            collision.collidesWith = ~((1 << layerToIgnore) | (1 << gameObject.layer));

        }
        Vector3 bloodDirection = Vector3.Normalize(bloodOwner.position - damageSource.position);
        print("Normal blood: " + bloodDirection);

        transform.rotation = Quaternion.LookRotation(bloodDirection);
        
        Destroy(gameObject, duration);
    }
}