using UnityEngine;

public class DashState : HeroineState
{
    private float dashSpeed = 5f;
    private Rigidbody2D rb;
    private float animationTimeCounter;
    public override void Enter(Heroine heroine)
    {
        rb = heroine.GetComponent<Rigidbody2D>();
        heroine.GetComponent<HeroineAnimatorController>().AnimateDash();
        animationTimeCounter = UtilityClass.GetAnimationLength(heroine.GetComponent<Animator>(), "dash");
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        animationTimeCounter -= Time.deltaTime;
        if (animationTimeCounter <= 0)
        {
            rb.velocity = Vector2.zero;
            return heroine.RetrieveLastState();
        }
        return base.HandleInput(heroine, input);
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        if (heroine.GetComponent<Heroine>().isFacingRight)
        {
            rb.velocity = Vector2.right*dashSpeed;
        }
        else
        {
            rb.velocity = -Vector2.right*dashSpeed;

        }
    }
}