using UnityEngine;

public class SplashBlood: MonoBehaviour, IBloodType
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


// public class DrippingBlood: MonoBehaviour
// {
//     [SerializeField] private float duration = 2f;
//     public void Setup(Transform bloodOwner)
//     {
//         transform.parent = bloodOwner;
//         
//         Destroy(gameObject, duration);
//         
//     }
// }