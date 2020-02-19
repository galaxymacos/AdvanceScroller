using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ReturnableComponent: MonoBehaviour
{
    private PlayerCharacter owner;
    [SerializeField] private float maxReturnSpeed = 10;
    [SerializeField] private float speedToGetMaxVelocity = 8;
    [SerializeField] private float maxDistanceToTravel = 10;
    private Vector2 originalPosition;
    private Rigidbody2D rb;
    private bool hasSetup;
    public Projectile projectile;

    public Action onReturnToOwner;
    

    private void Awake()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        onReturnToOwner += ResetProjectile;
    }

    private bool isReturningToOwner;

    public void Setup(Projectile projectile)
    {
        this.projectile = projectile;
        owner = projectile.owner;
        hasSetup = true;
    }

    public void Setup(PlayerCharacter owner)
    {
        this.owner = owner;
        hasSetup = true;
    }

    private void Update()
    {

        if (Vector2.Distance(originalPosition, transform.position) >= maxDistanceToTravel && !isReturningToOwner)
        {
            isReturningToOwner = true;
            onReturnToOwner?.Invoke();
            
        }

        if (isReturningToOwner)
        {
            Vector3 distanceToOwner = owner.transform.position - transform.position;
            float speedFactor = distanceToOwner.magnitude / speedToGetMaxVelocity;

            Vector3 returnDirection = distanceToOwner.normalized;
            Vector3 returnVelocity = speedFactor * maxReturnSpeed * returnDirection;
            rb.velocity = returnVelocity;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSetup || !isReturningToOwner) return;
        if (other.gameObject == owner.gameObject)
        {
            hasReturnedToOwner();
        }
    }

    public void hasReturnedToOwner()
    {
        Destroy(gameObject);
    }

    public void ResetProjectile()
    {
        GetComponent<Projectile>().ResetAttack();
    }
}