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


    public override HeroineState HandleInput(Heroine heroine, HeroineInput input)
    {
        animationTimeCounter -= Time.deltaTime;
        if (animationTimeCounter <= 0)
        {
            return GetComponent<IdleState>();
        }

        return null;
    }

    public override void update(Heroine heroine, HeroineInput input)
    {
    }

    public void SpawnWolf()
    {
        GameObject generatedWolf = Instantiate(wolf, transform.Find("SpawnLocations").Find("Wolf").position, transform.rotation);
        generatedWolf.GetComponent<WolfSkill>().moveRight = heroine.isFacingRight;

    }
}