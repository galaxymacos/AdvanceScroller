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

    public override HeroineState HandleInput(Heroine heroine, HeroineInput input)
    {
        if (input.attack)
        {
            return GetComponent<JumpAttackState>() ? GetComponent<JumpAttackState>(): gameObject.AddComponent<JumpAttackState>();
        }
        
        if (rb.velocity.y < 0)
        {
            return heroine.GetComponent<FallDownState>()? heroine.GetComponent<FallDownState>(): gameObject.AddComponent<FallDownState>();
        }
        
        

        return null;
    }

    public override void update(Heroine heroine, HeroineInput input)
    {
        horizontalMovement = input.horizontalMovement;
        rb.velocity = new Vector2(horizontalMovement* heroine.moveSpeedInair, rb.velocity.y);
    }
}