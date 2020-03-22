using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private CollisionDetector collisionDetector;

    [SerializeField] private DamageData damageData;
    
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;
    
    public bool isGrounded;
    

    public Transform groundDetectorLeft;
    public Transform groundDetectorRight;
    public Transform edgeDetector;
    public Transform wallDetector;

    public event Action OnHitPlayer;

    public bool isFacingRight => transform.localScale.x > 0;

    public PlayerCharacter owner;

    private void Awake()
    {
        collisionDetector.onObjectCollided += TryDealDamageToPlayer;
    }

    // The cat will follow the player's facing direction
    public void Setup(PlayerCharacter _owner)
    {
        owner = _owner;
        var localScale = transform.localScale;
        localScale = new Vector3(_owner.isFacingRight? localScale.x:-localScale.x, localScale.y);
        transform.localScale = localScale;
    }

    private void TryDealDamageToPlayer(GameObject target)
    {
        var healthComponent = target.GetComponent<CharacterHealthComponent>();
        var playerCharacter = target.GetComponent<PlayerCharacter>();
        if (healthComponent != null && playerCharacter != owner)
        {
            healthComponent.TakeDamage(damageData, transform, true);
            OnHitPlayer?.Invoke();
        }
        
    }
    
    

    private void Update()
    {
        isGrounded = IsGrounded();
    }

    public bool IsGrounded()
    {
        Collider2D left = Physics2D.OverlapCircle(groundDetectorLeft.position, 0.1f, whatIsGround);
        Collider2D right = Physics2D.OverlapCircle(groundDetectorRight.position, 0.1f, whatIsGround);
        return left != null && right != null;
    }


    public bool IsNearEdge()
    {
            return !Physics2D.OverlapCircle(edgeDetector.position, 0.1f, whatIsGround);
    }

    public bool IsNearWall()
    {
        return Physics2D.OverlapCircle(wallDetector.position, 0.1f, whatIsWall);
    }
}