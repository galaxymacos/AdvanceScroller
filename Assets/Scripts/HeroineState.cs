using UnityEngine;

public abstract class HeroineState : MonoBehaviour
{
    public abstract void Enter(Heroine heroine);

    public virtual HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        return null;
    }
    public abstract void update(Heroine heroine, PlayerOneInput input);
}