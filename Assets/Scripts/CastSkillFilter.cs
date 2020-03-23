using UnityEngine;

public abstract class CastSkillFilter
{
    public CastSkillFilter next;

    public string skillName;
    public CharacterStateMachineBehavior csmb;

    protected CastSkillFilter(string skillName,CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next)
    {
        this.skillName = skillName;
        csmb = characterStateMachineBehavior;
        this.next = next;
    }

    public bool FilterRecur()
    {
        if (next == null)
        {
            return Filter();
        }

        return next.FilterRecur() && Filter();
    }

    public void DealWithResultRecur()
    {
        DealWithResult();
        next?.DealWithResultRecur();
    }

    public abstract void DealWithResult();

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

    public override void DealWithResult()
    {
        playerSkillCooldownManager.Use(skillName);
    }

    protected override bool Filter()
    {
        bool result = playerSkillCooldownManager.CheckCooldown(skillName);
        if (result == false)
        {
            csmb.playerCharacter.GetComponent<ShaderController>().SkillOnCooldownEffect();
        }
        return result;
    }
}

public class ForceAttackFilter: CastSkillFilter
{
    public bool isForceUse;
    public ForceAttackFilter(string skillName, CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next) : base(skillName, characterStateMachineBehavior, next)
    {
    }

    public override void DealWithResult()
    {
        if (isForceUse)
        {
            ShadowFactory.instance.CreateForceCancelShadow(csmb.playerCharacter);    // TODO delete if it doesn't work
        }


        foreach (var animationAvailable in csmb.stateCanForceTransformTo)
        {
            if (skillName == animationAvailable)
            {
                CharacterEnergyComponent characterEnergy = csmb.characterAnimator.GetComponent<CharacterEnergyComponent>();
                characterEnergy.Consume(20);
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
                isForceUse = true;
                return characterEnergy.Check(20);
            }
        }

        isForceUse = false;
        return true;
    }
}

public class UltimateRageFilter : CastSkillFilter
{
    private bool isLastSkillUltimate;
    private readonly RageComponent ultimateComponent;
    public UltimateRageFilter(string skillName, CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next) : base(skillName, characterStateMachineBehavior, next)
    {
        ultimateComponent = csmb.playerCharacter.GetComponent<RageComponent>();
    }

    public override void DealWithResult()
    {
        if (isLastSkillUltimate)
        {
            csmb.playerCharacter.onPlayerUseUltimate?.Invoke();
        }
    }

    protected override bool Filter()
    {
        if (skillName != ultimateComponent.ultimateSkillName)
        {
            isLastSkillUltimate = false;
            return true;
        }

        isLastSkillUltimate = true;
        return ultimateComponent.canUseUltimate;
    }
}

public class LimitedUsageFilter: CastSkillFilter
{
    public LimitedUsageFilter(string skillName, CharacterStateMachineBehavior characterStateMachineBehavior, CastSkillFilter next) : base(skillName, characterStateMachineBehavior, next)
    {
    }


    public override void DealWithResult()
    {
        if (skillName == "acquire")
        {
            csmb.playerCharacter.GetComponentInChildren<ItemPickupComponent>().PickUpRandomItem();
        }

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
            case "climb":
                if (csmb.playerCharacter.isTouchingLadderLeft && csmb.playerCharacter.isTouchingLadderRight)
                {
                    return true;
                }

                return false;
            case "acquire":
                var itemPickupComponent = csmb.playerCharacter.GetComponentInChildren<ItemPickupComponent>();
                if (itemPickupComponent == null || !itemPickupComponent.HasItemNearBy) return false;
                return true;
        }

        // The current skill is not limited 
        return true;
    }
}

public class CharacterEventSystem : MonoBehaviour
{
    
}

