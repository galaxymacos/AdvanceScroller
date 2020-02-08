using UnityEngine;

public class ProjectileMovementComponent: MovementComponent
{
    private readonly float moveAngle;
    private readonly Transform entity;
    private readonly float movementSpeed;
    private PlayerCharacter owner;

    private readonly Vector2 moveDirection;

    public ProjectileMovementComponent(float moveAngle, Transform entity, float movementSpeed, PlayerCharacter owner)
    {
        this.moveAngle = moveAngle;
        this.entity = entity;
        this.movementSpeed = movementSpeed;
        this.owner = owner;

        Vector2 ownerFacingDirection = owner.isFacingRight ? new Vector2(1, 0) : new Vector2(-1, 0);
        if (owner.isFacingRight)
        {
            moveDirection = Quaternion.AngleAxis(this.moveAngle, Vector3.forward) * ownerFacingDirection;
        }
        else
        {
            moveDirection = Quaternion.AngleAxis(-this.moveAngle, Vector3.forward) * ownerFacingDirection;

        }
        
        
        var projectileFacing = entity.localScale;
        if (moveDirection.x < 0)
        {
            projectileFacing = new Vector3(-projectileFacing.x, projectileFacing.y, projectileFacing.z);
            entity.localScale = projectileFacing;
            entity.Rotate(0,0,-this.moveAngle);
        }
        else
        {
            projectileFacing = new Vector3(projectileFacing.x, projectileFacing.y, projectileFacing.z);
            entity.Rotate(0,0,this.moveAngle);

        }

    }
    
    public override void UpdateMovement()
    {
        entity.Translate(  moveDirection *(Time.deltaTime * movementSpeed));

    }
}