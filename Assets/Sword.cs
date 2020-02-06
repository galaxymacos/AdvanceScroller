using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private ProjectileFlipComponent flipComponent;
    private ProjectileMovementComponent movementComponent;
    public bool moveRight;
    public float movementSpeed = 7f;
    
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
}


