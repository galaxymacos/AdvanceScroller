using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // public float movementSpeed = 5f;
    private ProjectileMovementComponent movementComponent;
    public PlayerCharacter owner;

    private bool setupFinished;

    // Start is called before the first frame update

    public void Setup(PlayerCharacter _owner, float movementSpeed = 5 , float angle = 0)
    {
        owner = _owner;
        movementComponent = new ProjectileMovementComponent(angle, transform, movementSpeed, owner);
        setupFinished = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (setupFinished)
        {
            movementComponent.UpdateMovement();
        }
    }

    // Call it animation
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    
    
}