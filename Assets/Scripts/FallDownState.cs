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

    public override HeroineState HandleInput(Heroine heroine, HeroineInput input)
    {
        if (heroine.isGrounded)
        {
            return GetComponent<IdleState>();
        }

        if (input.attack)
        {
            return GetComponent<JumpAttackState>() ? GetComponent<JumpAttackState>(): gameObject.AddComponent<JumpAttackState>();
        }
        
        return null;
    }

    public override void update(Heroine heroine, HeroineInput input)
    {
        horizontalMovement = input.horizontalMovement;
        rb.velocity = new Vector2(horizontalMovement* heroine.moveSpeedInair, rb.velocity.y);
    }
}