using System;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectile: MonoBehaviour
{
    // public float movementSpeed = 5f;
    public GameObject owner;
    private Rigidbody2D rb;
    private IDamageReceiver ownerDamageReceiver;

    public class ProjectileArgument
    {
        public ProjectileArgument(GameObject owner)
        {
            this.owner = owner;
        }
        public GameObject owner;
    }

    public event Action<ProjectileArgument> onProjectileSetupFinished;

    public void Setup(GameObject _owner, float movementSpeed = 100 , float angle = 0, bool customRotation = false)
    {
        owner = _owner;

        ownerDamageReceiver = _owner.GetComponent<IDamageReceiver>();
        rb = GetComponent<Rigidbody2D>();
        
        Vector2 ownerFacingDirection;
        if (owner.GetComponent<PlayerCharacter>())
        {
            ownerFacingDirection = owner.GetComponent<PlayerCharacter>().isFacingRight ? new Vector2(1, 0) : new Vector2(-1, 0);
        }
        else
        {
            print("Tennis ball owner: "+_owner);
            ownerFacingDirection = owner.GetComponent<FacingComponent2D>().IsFacingRight ? new Vector2(1, 0) : new Vector2(-1, 0);
        }
        
        Vector2 moveDirection;
        if (owner.GetComponent<PlayerCharacter>())
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