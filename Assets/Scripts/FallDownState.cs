using UnityEngine;

public class FallDownState : HeroineState
{
    private float horizontalMovement;
    private Rigidbody2D rb;
    public override void Enter(Heroine heroine)
    {
        heroine.GetComponent<HeroineAnimatorController>().AnimateFalldown();
        rb = heroine.GetComponent<Rigidbody2D>();
        
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        if (heroine.isGrounded)
        {
            return GetComponent<IdleState>();
        }

        if (input.attackButtonPressed)
        {
            return GetComponent<JumpAttackState>() ? GetComponent<JumpAttackState>(): gameObject.AddComponent<JumpAttackState>();
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
        return base.HandleInput(heroine, input);
        
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        horizontalMovement = input.horizontalAxis;
        rb.velocity = new Vector2(horizontalMovement* heroine.moveSpeedInair, rb.velocity.y);
    }
}