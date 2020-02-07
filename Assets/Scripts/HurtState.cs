using UnityEngine;

public class HurtState : HeroineState
{
    public override void Enter(Heroine heroine)
    {
        heroine.GetComponent<HeroineAnimatorController>().AnimateHurt();
        
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        return base.HandleInput(heroine, input);
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        
    }

}