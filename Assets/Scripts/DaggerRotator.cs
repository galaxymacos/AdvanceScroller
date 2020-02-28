using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class DaggerRotator : MonoBehaviour
{

    public float growUpTime = 2f;

    private float growUpTimeCounter;

    public float rotateSpeed = 90f;
    public float sizeIncreaseFactor = 1f;
    public bool hasGrownUp;
    public bool hasShoot;
    private Projectile projectile;
    private PlayerCharacter owner;

    private bool hasSetup;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Projectile>();
        growUpTimeCounter = growUpTime;
    }

    public void Setup(PlayerCharacter owner)
    {
        this.owner = owner;
        if (owner.isFacingRight)
        {
            facingRight = true;
        }
        else
        {
            transform.localScale =
                new Vector3(-transform.localScale.x, transform.localScale.y);
            facingRight = false;
        }
        hasSetup = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSetup) return;
        
        
        GrowUp();

        Rotate();

        if (!hasGrownUp)
        {
            transform.localScale *= (1 + sizeIncreaseFactor * Time.deltaTime);
        }

        if (hasGrownUp)
        {
            
        }

    }

    private void Rotate()
    {
        if (hasGrownUp && !hasShoot)
        {
            if (facingRight)
            {
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);

            }
        }
    }

    private void GrowUp()
    {
        if (growUpTimeCounter >= 0)
        {
            growUpTimeCounter -= Time.deltaTime;
            if (growUpTimeCounter < 0)
            {
                hasGrownUp = true;
            }
        }
    }

    public void Shoot()
    {
        hasShoot = true;
        projectile.Setup(owner, 100, facingRight?transform.rotation.eulerAngles.z:-transform.rotation.eulerAngles.z, true);
    }
    
    
}
