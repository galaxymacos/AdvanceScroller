using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockable : MonoBehaviour
{
    public string knockupAnimationString = "hurt";
    private Rigidbody2D rb;
    [HideInInspector]public Vector2 knockDirection;

    public void KnockUp(float knockHorizontalForce, float knockVerticalForce, Transform knocker)
    {
        
        Vector3 knockerLocation = knocker.position;
        Vector3 knockableLocation = transform.position;

        print(knocker.name);

        var projectileInKnocker = knocker.GetComponent<Projectile>();
        
        Vector2 knockDirectionHorizontal;
        
        // Knocked by projectile
        if (projectileInKnocker != null)
        {
            knockDirectionHorizontal = projectileInKnocker.GetComponent<Rigidbody2D>().velocity.x > 0 ? Vector2.right : Vector2.left;
        }
        else // Knocked by character
        {
            if (knockerLocation.x - knockableLocation.x > 0)
            {
                knockDirectionHorizontal = Vector2.left;
            }
            else
            {
                knockDirectionHorizontal = Vector2.right;
            }
        }
        
        if(knockDirectionHorizontal == Vector2.left)
        {
           print("knock to left"); 
        }
        else
        {
            print("knock to right");
        }
        

        knockDirection = knockDirectionHorizontal * knockHorizontalForce+new Vector2(0,knockVerticalForce);
        GetComponent<Animator>().SetTrigger(knockupAnimationString);    
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}
