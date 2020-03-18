using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushComponent : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public Vector2 pushDirection;
    public float pushSpeed;
    public float pushDistance;
    public Action<Vector2> onHitWall;
    public Action<Vector2> onHitGround;
    public Action<Vector2> onHitCeiling;

    public float checkRadius = 0.05f;
    public Transform wallRightCheck;
    public bool isNextToWallRight;
    public Transform wallLeftCheck;
    public bool isNextToWallLeft;
    public Transform groundCheck;
    private bool wasOnGrounded;
    public LayerMask whatIsWall;
    private bool wasHitCeiling;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Push(Transform damageSource, float speed, float pushDistance)
    {
        print(gameObject.name+" is being pushed");

        if (!playerCharacter.isNextToWallRight && !playerCharacter.isNextToWallLeft)
        {
            print(gameObject.name+" is being pushed ++++");

            pushDirection = Vector3.Normalize(transform.position - damageSource.position);
            pushSpeed = speed;
            this.pushDistance = pushDistance;
            GetComponent<Animator>().SetTrigger("push");
        }
    }

    /// <summary>
    /// Push the player to a specific angle
    /// </summary>
    /// <param name="damageSource"></param>
    /// <param name="speed"></param>
    /// <param name="angleOffset"></param>
    public void Push(Transform damageSource, float speed, float angleOffset, float pushDistance)
    {
        print(gameObject.name+" is being pushed");

        if (angleOffset < 0 && playerCharacter.IsGrounded)
        {
            return;
        }

        if (!playerCharacter.isNextToWallRight && !playerCharacter.isNextToWallLeft)
        {
            
            print(gameObject.name+" is being pushed ++++++");

            Vector2 relativePositionBetweenActors = (damageSource.position.x - playerCharacter.transform.position.x) < 0
                ? new Vector2(1, 0)
                : new Vector2(-1, 0);
            if (damageSource.GetComponent<PlayerCharacter>().isFacingRight)
            {
                pushDirection = Quaternion.AngleAxis(angleOffset, Vector3.forward) * relativePositionBetweenActors;
                print("push to right");
            }
            else
            {
                pushDirection = Quaternion.AngleAxis(-angleOffset, Vector3.forward) * relativePositionBetweenActors;
                print("push to left");
            }

            pushSpeed = speed;
            this.pushDistance = pushDistance;
            GetComponent<Animator>().SetTrigger("push");
            GetComponent<Animator>().SetBool("Test", true);
            print("Set push animation parameter");

        }
    }

    private void Update()
    {
        bool wasNextToWallRight = isNextToWallRight;
        isNextToWallRight = Physics2D.OverlapCircle(wallRightCheck.position, checkRadius, whatIsWall);
        if (wasNextToWallRight != isNextToWallRight && isNextToWallRight)
        {
            onHitWall?.Invoke(wallRightCheck.position);
        }

        bool wasNextToWallLeft = isNextToWallLeft;
        isNextToWallLeft = Physics2D.OverlapCircle(wallLeftCheck.position, checkRadius, whatIsWall);
        if (wasNextToWallLeft != isNextToWallLeft && isNextToWallLeft)
        {
            onHitWall?.Invoke(wallLeftCheck.position);
        }

        if (playerCharacter.IsGrounded && wasOnGrounded == false)
        {
            onHitGround?.Invoke(playerCharacter.groundCheck.position);
        }
        wasOnGrounded = playerCharacter.IsGrounded;

        if (playerCharacter.isHitCeiling && wasHitCeiling == false)
        {
            onHitCeiling?.Invoke(playerCharacter.ceilingCheck.position);
        }
        wasHitCeiling = playerCharacter.isHitCeiling;
    }
}