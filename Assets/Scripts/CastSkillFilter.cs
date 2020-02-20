public abstract class CastSkillFilter
{
    public CastSkillFilter next;

    public string skillName;
    public CharacterStateMachineBehavior csmb;

    protected CastSkillFilter(string skillName,CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next)
    {
        this.skillName = skillName;
        csmb = characterStateMachineBehavior;
    }

    public bool FilterRecur()
    {
        return (next == null || next.Filter()) && Filter() ;
    }

    public void DealWithResultRecur()
    {
        DealWithResult();
        next.DealWithResult();
    }

    protected abstract void DealWithResult();

    // Write filter logic here
    protected abstract bool Filter();
}

public class CooldownFilter : CastSkillFilter
{
    private SkillCooldownManager playerSkillCooldownManager;
    public CooldownFilter(string skillName, CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next) : base(skillName, characterStateMachineBehavior, next)
    {
        playerSkillCooldownManager = characterStateMachineBehavior.playerCharacter.GetComponent<SkillCooldownManager>();
    }

    protected override void DealWithResult()
    {
        playerSkillCooldownManager.Use(skillName);
    }

    protected override bool Filter()
    {
        return playerSkillCooldownManager.CheckCooldown(skillName);
    }
}

public class ForceAttackFilter: CastSkillFilter
{
    
    public ForceAttackFilter(string skillName, CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next) : base(skillName, characterStateMachineBehavior, next)
    {
    }

    protected override void DealWithResult()
    {
        foreach (var animationAvailable in csmb.stateCanForceTransformTo)
        {
            if (skillName == animationAvailable)
            {
                CharacterEnergyComponent characterEnergy = csmb.characterAnimator.GetComponent<CharacterEnergyComponent>();
                characterEnergy.Consume(30);
                return;
            }
        }
    }

    protected override bool Filter()
    {
        foreach (var forcableAnimation in csmb.stateCanForceTransformTo)
        {
            if (skillName == forcableAnimation)
            {
                CharacterEnergyComponent characterEnergy = csmb.characterAnimator.GetComponent<CharacterEnergyComponent>();
                return characterEnergy.Check(30);
            }
        }
        throw new System.NotImplementedException();
    }
}

public class LimitedUsageFilter: CastSkillFilter
{
    public LimitedUsageFilter(string skillName, CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next) : base(skillName, characterStateMachineBehavior, next)
    {
    }

    protected override void DealWithResult()
    {
        return;
    }

    protected override bool Filter()
    {
        switch (skillName)
        {
            case "dash":
                if (csmb.playerCharacter.dashTimeCounter < csmb.playerCharacter.maxDashTimeInAir)
                {
                    return true;
                }

                return false;

            case "jump":
                if (csmb.playerCharacter.jumpTime < csmb.playerCharacter.maxJumpTime)
                {
                    return true;
                }

                return false;
        }

        // The current skill is not limited 
        return true;
    }
}


