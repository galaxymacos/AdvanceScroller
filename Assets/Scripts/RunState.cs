using UnityEngine;

public class RunState : GroundMovementState
{
    private Rigidbody2D rb;
    private float horizontalMovement;

    public override void Enter(Heroine heroine)
    {
        base.Enter(heroine);
        rb = GetComponent<Rigidbody2D>();
        heroine.GetComponent<HeroineAnimatorController>().AnimateRun();
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
        
        if (Mathf.Abs(horizontalMovement) < Mathf.Epsilon)
        {
            if (GetComponent<IdleState>() != null)
            {
                return GetComponent<IdleState>();
            }
            else
            {
                return gameObject.AddComponent<IdleState>();
            }
        }

        return null;
    }

    public override void update(Heroine heroine, PlayerOneInput input)
    {
        base.update(heroine, input);
        horizontalMovement = input.horizontalAxis;
        rb.velocity = new Vector2(horizontalMovement* heroine.runSpeed, rb.velocity.y);
    }

}