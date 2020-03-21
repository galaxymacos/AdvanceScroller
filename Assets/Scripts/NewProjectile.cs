using System;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectile: MonoBehaviour
{
    // public float movementSpeed = 5f;
    public PlayerCharacter owner;
    private Rigidbody2D rb;

    public class ProjectileArgument
    {
        public ProjectileArgument(PlayerCharacter owner)
        {
            this.owner = owner;
        }
        public PlayerCharacter owner;
    }

    public event Action<ProjectileArgument> onProjectileSetupFinished;

    public void Setup(PlayerCharacter _owner, float movementSpeed = 100 , float angle = 0, bool customRotation = false)
    {
        rb = GetComponent<Rigidbody2D>();
        owner = _owner;
        Vector2 ownerFacingDirection = owner.isFacingRight ? new Vector2(1, 0) : new Vector2(-1, 0);
        Vector2 moveDirection;
        if (owner.isFacingRight)
        {
            moveDirection = Quaternion.AngleAxis(angle, Vector3.forward) * ownerFacingDirection;
        }
        else
        {
            moveDirection = Quaternion.AngleAxis(-angle, Vector3.forward) * ownerFacingDirection;

        }
        rb.AddForce(moveDirection * (movementSpeed * 20));

        if (!customRotation)
        {
            var projectileFacing = transform.localScale;
            if (moveDirection.x < 0)
            {
                projectileFacing = new Vector3(-projectileFacing.x, projectileFacing.y, projectileFacing.z);
                transform.localScale = projectileFacing;
                transform.Rotate(0,0,-angle);
            }
            else
            {
                projectileFacing = new Vector3(projectileFacing.x, projectileFacing.y, projectileFacing.z);
                transform.Rotate(0,0,angle);

            }
        }
        
        
        onProjectileSetupFinished?.Invoke(new ProjectileArgument(_owner));

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}