using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSkill : MonoBehaviour
{
    public float movementSpeed = 5f;
    public bool moveRight;
    private ProjectileFlipComponent flipComponent;
    private ProjectileMovementComponent movementComponent;

    // Start is called before the first frame update
    void Start()
    {
        flipComponent = new ProjectileFlipComponent(transform, moveRight);
        movementComponent = new ProjectileMovementComponent(moveRight, transform, movementSpeed);
    }    
    
    // Update is called once per frame
    void Update()
    {
        flipComponent.Flip();
        movementComponent.UpdateMovement();
    }

    // Call it animation
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    
    
}

public class ProjectileMovementComponent: MovementComponent
{
    private bool moveRight;
    private Transform entity;
    private float movementSpeed;

    public ProjectileMovementComponent(bool moveRight, Transform entity, float movementSpeed)
    {
        this.moveRight = moveRight;
        this.entity = entity;
        this.movementSpeed = movementSpeed;
    }
    
    public override void UpdateMovement()
    {
        entity.Translate(  (moveRight?Vector2.right:Vector2.left) *(Time.deltaTime * movementSpeed));

    }
}