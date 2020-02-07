using UnityEngine;

public class JumpState : HeroineState
{
    private float horizontalMovement;
    private Rigidbody2D rb;
    public override void Enter(Heroine heroine)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x,heroine.jumpForce);
        heroine.GetComponent<HeroineAnimatorController>().AnimateJump();

    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        if (input.attackButtonPressed)
        {
            return GetComponent<JumpAttackState>() ? GetComponent<JumpAttackState>(): gameObject.AddComponent<JumpAttackState>();
        }
        
        if (rb.velocity.y < 0)
        {
            return heroine.GetComponent<FallDownState>()? heroine.GetComponent<FallDownState>(): gameObject.AddComponent<FallDownState>();
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
        horizontalMovement = input.horizontalAxis;
        rb.velocity = new Vector2(horizontalMovement* heroine.moveSpeedInair, rb.velocity.y);
    }
}