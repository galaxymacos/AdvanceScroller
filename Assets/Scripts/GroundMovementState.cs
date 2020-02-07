public class GroundMovementState : HeroineState
{
    public override void Enter(Heroine heroine)
    {
        
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        if (input.jumpButtonPressed)
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

        if (input.dashButtonPressed)
        {
            print("dashButtonPressed");
            if (GetComponent<DashState>())
            {
                return GetComponent<DashState>();
            }
            else
            {
                return gameObject.AddComponent<DashState>();
            }
        }
        return null;
        
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        
    }
}