using UnityEngine;

public class AttackState : HeroineState
{
    private float animationTime;
    private float animationTimeCounter;
    private bool playerHitAttack;
    public override void Enter(Heroine heroine)
    {
        heroine.GetComponent<PlayerOneInput>().attackButtonPressed = false;

        Reset();
        
        heroine.GetComponent<Rigidbody2D>().velocity = new Vector2(0, heroine.GetComponent<Rigidbody2D>().velocity.y);
        heroine.GetComponent<HeroineAnimatorController>().AnimateAttack();
        animationTime = UtilityClass.GetAnimationLength(heroine.animator, "attack");
        animationTimeCounter = animationTime;
    }

    public void Reset()
    {
        playerHitAttack = false;
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {

        if (input.attackButtonPressed)
        {
            // Consume player input
            input.attackButtonPressed = false;
            playerHitAttack = true;
        }
        
        animationTimeCounter -= Time.deltaTime;
        if (animationTimeCounter <= 0)
        {
            if (playerHitAttack)
            {
                return heroine.GetComponent<Skill1State>()?heroine.GetComponent<Skill1State>():gameObject.AddComponent<Skill1State>();
            }
            return heroine.RetrieveLastState();
        }
        return base.HandleInput(heroine, input);
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
    }
}