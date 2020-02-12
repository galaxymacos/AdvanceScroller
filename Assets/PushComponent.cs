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
    

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Push(Transform damageSource, float speed)
    {
        pushDirection = Vector3.Normalize(damageSource.position - transform.position);
        pushSpeed = speed;
        
        GetComponent<Animator>().SetTrigger("push");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerCharacter.whatIsWall)
        {
            onHitWall?.Invoke(other.ClosestPoint(transform.position));
        }
        if (other.gameObject.layer == playerCharacter.whatIsGround)
        {
            onHitGround?.Invoke(other.ClosestPoint(transform.position));
        }
    }
}
