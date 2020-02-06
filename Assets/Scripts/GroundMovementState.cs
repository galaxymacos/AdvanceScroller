public class GroundMovementState : HeroineState
{
    public override void Enter(Heroine heroine)
    {
        
    }

    public override HeroineState HandleInput(Heroine heroine, HeroineInput input)
    {
        if (input.jump)
        {
            if (GetComponent<JumpState>())
            {
                return GetComponent<JumpState>();
            }
            else
            {
                return gameObject.AddComponent<JumpState>();
            }
        }
        return null;

    }

    public override void update(Heroine heroine, HeroineInput input)
    {
        
    }
}