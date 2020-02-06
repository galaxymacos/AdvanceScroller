using UnityEngine;

public abstract class HeroineState : MonoBehaviour
{
    public abstract void Enter(Heroine heroine);

    public virtual HeroineState HandleInput(Heroine heroine, HeroineInput input)
    {
        if (input.hurt)
        {
            return heroine.GetComponent<HurtState>()?heroine.GetComponent<HurtState>():gameObject.AddComponent<HurtState>();
        }

        return null;
    }
    public abstract void update(Heroine heroine, HeroineInput input);
}