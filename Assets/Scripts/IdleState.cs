using System;
using UnityEngine;

public class IdleState : GroundMovementState
{
    private float horizontalMovement;

    public override void Enter(Heroine heroine)
    {
        base.Enter(heroine);
        heroine.GetComponent<HeroineAnimatorController>().AnimateIdle();
    }

    public override HeroineState HandleInput(Heroine heroine, PlayerOneInput input)
    {
        var state = base.HandleInput(heroine, input);
        if (state != null)
        {
            return state;
        }

        if (input.attackButtonPressed)
        {
            if (GetComponent<AttackState>() != null)
            {
                return GetComponent<AttackState>();
            }
            else
            {
                return gameObject.AddComponent<AttackState>();
            }

        }
        
        if (Mathf.Abs(input.horizontalAxis) > Mathf.Epsilon)
        {
            if (GetComponent<RunState>() != null)
            {
                return GetComponent<RunState>();
            }
            else
            {
                return gameObject.AddComponent<RunState>();
            }
        }
        return null;
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        base.update(heroine, input);
        
    }
}