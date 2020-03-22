using UnityEngine;

public class NormalBlood: MonoBehaviour, IBloodType
{
    [SerializeField] private float duration = 2f;
    public void Setup(Transform damageSource, Transform bloodOwner)
    {
        Vector3 bloodDirection = Vector3.Normalize(damageSource.position - bloodOwner.position);
        transform.rotation = Quaternion.LookRotation(bloodDirection);
        transform.parent = bloodOwner;
        
        Destroy(gameObject, duration);
        
    }
}