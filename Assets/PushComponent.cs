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
    public LayerMask whatIsWall;
    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Push(Transform damageSource, float speed)
    {
        pushDirection = Vector3.Normalize(transform.position - damageSource.position );
        pushSpeed = speed;
        
        GetComponent<Animator>().SetTrigger("push");
        print("push");
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
    }
}
