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

        Vector2 knockDirectionHorizontal;
        if (knockerLocation.x - knockableLocation.x > 0)
        {
            knockDirectionHorizontal = Vector2.left;
        }
        else
        {
            knockDirectionHorizontal = Vector2.right;
        }

        knockDirection = knockDirectionHorizontal * knockHorizontalForce+new Vector2(0,knockVerticalForce);
        GetComponent<Animator>().SetTrigger(knockupAnimationString);    
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}
