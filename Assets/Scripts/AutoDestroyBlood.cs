using UnityEngine;

public class AutoDestroyBlood : MonoBehaviour, IBloodType
{
    [SerializeField] private float duration = 2f;
    public void Setup(Transform damageSource, Transform bloodOwner)
    {
        Destroy(gameObject, duration);
    }
}