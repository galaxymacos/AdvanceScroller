using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockable : MonoBehaviour
{
    public string knockupAnimationString = "hurt";
    private Rigidbody2D rb;
    [HideInInspector]public Vector2 knockDirection;


    public class KnockupData
    {
        public KnockupData(float knockHorizontalForce, float knockVerticalForce, Transform knocker)
        {
            this.knockHorizontalForce = knockHorizontalForce;
            this.knockVerticalForce = knockVerticalForce;
            knockupPosition = knocker.position;
        }
        
        public float knockHorizontalForce;
        public float knockVerticalForce;
        public Vector2 knockupPosition;
    }

    public KnockupData data;

    
    public void KnockUp(float knockHorizontalForce, float knockVerticalForce, Transform knocker)
    {
        if (GameStateMachine.gameIsPause)
        {
            GetComponent<Animator>().SetTrigger(knockupAnimationString);
            if (data == null)
            {
                data = new KnockupData(knockHorizontalForce, knockVerticalForce, knocker);
            }
            else
            {
                data.knockHorizontalForce += knockHorizontalForce;
                data.knockVerticalForce += knockVerticalForce;
            }
            return; // TODO store force
        }
        
        print("Knock up");
        Vector3 knockerLocation = knocker.position;
        Vector3 knockableLocation = transform.position;


        
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
    
    private void KnockUp(float knockHorizontalForce, float knockVerticalForce, Vector3 knockPosition)
    {
        
        Vector3 knockableLocation = transform.position;
        Vector2 knockDirectionHorizontal;
        
        // Knocked by projectile
        {
            if (knockPosition.x - knockableLocation.x > 0)
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
        GameStateMachine.gameUnPause += UnPause;
        
    }

    private void OnDestroy()
    {
        GameStateMachine.gameUnPause -= UnPause;
    }

    public void UnPause()
    {
        print("game is unpause");
        if (data != null)
        {
            KnockUp(data.knockHorizontalForce, data.knockVerticalForce, data.knockupPosition);
            data = null;
        }
    }
}