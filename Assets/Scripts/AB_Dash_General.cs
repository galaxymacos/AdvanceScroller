using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Dash_General : CharacterStateMachineBehavior
{
    [SerializeField] private float dashSpeed = 8;
    private bool isDashReversed;
    [SerializeField] private float dashDuration = 0.4f;
    private bool dashRight;
    private bool hasActivatedBulletTime;
    private bool hitEnemy;

    private float dashTimeCounter;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        hitEnemy = false;
        hasActivatedBulletTime = false;
        dashTimeCounter = dashDuration;
        if (!playerCharacter.isGrounded)
        {
            playerCharacter.dashTimeCounter++;
        }

        dashRight = playerCharacter.isFacingRight;
        if (playerCharacter.isFacingRight && playerInput.horizontalAxis < 0)
        {
            Vector3 localScale = playerCharacter.transform.localScale;
            localScale.x = -1;
            playerCharacter.onFacingDirectionChanged?.Invoke();
            playerCharacter.transform.localScale = localScale;
            
            isDashReversed = true;
        }
        else if (!playerCharacter.isFacingRight && playerInput.horizontalAxis > 0)
        {
            Vector3 localScale = playerCharacter.transform.localScale;
            localScale.x = 1;
            playerCharacter.onFacingDirectionChanged?.Invoke();
            playerCharacter.transform.localScale = localScale;
            
            isDashReversed = true;
        }
        else
        {
            isDashReversed = false;
        }

        playerCharacter.dashInvincibleTimeCounter = playerCharacter.dashInvincibleTime;
        // event
        playerCharacter.onPlayerStartDash?.Invoke();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        dashTimeCounter -= Time.deltaTime;
        if (dashTimeCounter <= 0)
        {
            _animator.SetTrigger("idle");
        }

        Rigidbody2D rb = _animator.GetComponent<Rigidbody2D>();

        if (!isDashReversed)
        {
            if (playerCharacter.isFacingRight && playerCharacter.atEnemyLeft)
            {
                rb.velocity = Vector3.zero;
                hitEnemy = true;
            }
            else if (!playerCharacter.isFacingRight && playerCharacter.atEnemyRight)
            {
                rb.velocity = Vector3.zero;
                hitEnemy = true;
            }
        }
        

        if (!hitEnemy)
        {
            if (dashRight)
            {
                rb.velocity = Vector2.right * (dashSpeed * (isDashReversed ? -1 : 1));
            }
            else
            {
                rb.velocity = -Vector2.right * (dashSpeed * (isDashReversed ? -1 : 1));
            }
        }    

        if (playerInput.dashButtonPressed)
        {
            playerInput.dashButtonPressed = false;
            characterAnimator.SetTrigger("idle");
        }
    }

    public override void OnStateExit(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(_animator, stateInfo, layerIndex);
        playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void ActivateDodgeBulletTime()
    {
        if (!hasActivatedBulletTime)
        {
            BulletTimeManager.instance.Register(0.2f);
            hasActivatedBulletTime = true;
        }
    }
}