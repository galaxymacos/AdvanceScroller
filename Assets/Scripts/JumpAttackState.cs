using UnityEngine;

public class JumpAttackState : HeroineState
{
    private Animator animator;
    private float animationTime;
    private float animationTimeCounter;
    private Rigidbody2D rb;
    public override void Enter(Heroine heroine)
    {
        rb = heroine.GetComponent<Rigidbody2D>();
        animator = heroine.animator;
        animationTime = UtilityClass.GetAnimationLength(heroine.animator, "jump attack");
        animationTimeCounter = animationTime;
        heroine.GetComponent<HeroineAnimatorController>().AnimateJumpAttack();
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        animationTimeCounter -= Time.deltaTime;
        if (animationTimeCounter <= 0)
        {
            return GetComponent<FallDownState>() ? GetComponent<FallDownState>(): gameObject.AddComponent<FallDownState>();

        }
        
        
        return null;
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        rb.velocity = new Vector2(input.horizontalAxis* heroine.moveSpeedInair, rb.velocity.y);
    }
    
   
}