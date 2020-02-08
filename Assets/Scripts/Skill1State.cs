using UnityEngine;

public class Skill1State : HeroineState
{
    public float animationTimeCounter;
    public GameObject wolf;
    private Heroine heroine;
    public override void Enter(Heroine heroine)
    {
        // consume the input
        Reset();
        this.heroine = heroine;
        
        heroine.GetComponent<HeroineAnimatorController>().AnimateSkill1();
        animationTimeCounter = UtilityClass.GetAnimationLength(heroine.animator, "skill1");
    }

    public void Reset()
    {
        animationTimeCounter = 0;
    }


    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        animationTimeCounter -= Time.deltaTime;
        if (animationTimeCounter <= 0)
        {
            return GetComponent<IdleState>();
        }

        return null;
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
    }

    
}