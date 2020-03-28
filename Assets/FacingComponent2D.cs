using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingComponent2D : MonoBehaviour
{
    private FacingCondition facingCondition = FacingCondition.None;
    public bool IsFacingRight => transform.localScale.x > 0f;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ChangeFacing()
    {
        var localScale = transform.localScale;
        localScale.x = -localScale.x;
        transform.localScale = localScale;
    }

    public void SetFacingBy(FacingCondition _facingCondition)
    {
        this.facingCondition = _facingCondition;
    }
    
    

    private void Update()
    {
        switch (facingCondition)
        {
            case FacingCondition.None:
                break;
            case FacingCondition.ByVelocity:
                var localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
                if (rigidBody.velocity.x > 0)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
                else if (rigidBody.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum FacingCondition
{
    None,
    ByVelocity
}
