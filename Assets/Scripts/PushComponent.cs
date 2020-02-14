using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushComponent : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public Vector2 pushDirection;
    public float pushSpeed;
    public Action<Vector2> onHitWall;
    public Action<Vector2> onHitGround;

    public float checkRadius = 0.05f;
    public Transform wallRightCheck;
    public bool isNextToWallRight;
    public Transform wallLeftCheck;
    public bool isNextToWallLeft;
    public Transform groundCheck;
    private bool wasOnGrounded;
    public LayerMask whatIsWall;
    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Push(Transform damageSource, float speed)
    {
        if (!playerCharacter.isNextToWallRight && !playerCharacter.isNextToWallLeft)
        {
            pushDirection = Vector3.Normalize(transform.position - damageSource.position );
            pushSpeed = speed;
        
            GetComponent<Animator>().SetTrigger("push");
        }
        
    }

    public void Push(Transform damageSource, float speed, float angleOffset)
    {
        if (angleOffset < 0)
        {
            if (!playerCharacter.isGrounded && !playerCharacter.isNextToWallRight && !playerCharacter.isNextToWallLeft)
            {
                Vector2 ownerFacingDirection = (damageSource.position.x - playerCharacter.transform.position.x)<0 ? new Vector2(1, 0) : new Vector2(-1, 0);
                if (playerCharacter.isFacingRight)
                {
                    pushDirection = Quaternion.AngleAxis(angleOffset, Vector3.forward) * ownerFacingDirection;
                }
                else
                {
                    pushDirection = Quaternion.AngleAxis(-angleOffset, Vector3.forward) * ownerFacingDirection;

                }

                pushSpeed = speed;
                GetComponent<Animator>().SetTrigger("push");
            }
            
            



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

        if (playerCharacter.isGrounded && wasOnGrounded == false)
        {
            onHitGround?.Invoke(playerCharacter.groundCheck.position);
        }
        wasOnGrounded = playerCharacter.isGrounded;
        
    }
}
