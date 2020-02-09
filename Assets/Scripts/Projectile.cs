using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : CollisionDetector
{
    // public float movementSpeed = 5f;
    private ProjectileMovementComponent movementComponent;
    public PlayerCharacter owner;
    public GameObject deadParticle;
    public Action<GameObject> onProjectileCollided;
    private List<GameObject> _objectsHasCollided;

    private bool setupFinished;

    public void Setup(PlayerCharacter _owner, float movementSpeed = 5 , float angle = 0)
    {
        owner = _owner;
        movementComponent = new ProjectileMovementComponent(angle, transform, movementSpeed, owner);
        setupFinished = true;
    }

    private void Awake()
    {
        onObjectCollided = FilterOwn;
        _objectsHasCollided = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (setupFinished)
        {
            movementComponent.UpdateMovement();
        }
    }

    private void OnDestroy()
    {
        if (deadParticle != null)
        {
            var swordDisappear = Instantiate(deadParticle, transform.position, Quaternion.identity);
            swordDisappear.transform.localScale = transform.localScale;
            swordDisappear.transform.rotation = transform.rotation;
        }
        
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void FilterOwn(GameObject objectCollided)
    {
        if (objectCollided != owner.gameObject)
        {
            if (!_objectsHasCollided.Contains(objectCollided))
            {
                _objectsHasCollided.Add(objectCollided);
                onProjectileCollided?.Invoke(objectCollided);
            }
        }
    }
}