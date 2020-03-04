using UnityEngine;

public abstract class MaterialController:MonoBehaviour
{
    [SerializeField] protected Material material;
    protected SpriteRenderer _sr;
    
    public abstract void Run(SpriteRenderer sr);

}

