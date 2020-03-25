using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SignRoationAnimControl : MonoBehaviour
{
    Animator animator;
    bool signIsTouched;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        PlayerCharacter playerCharacter = other.GetComponent<PlayerCharacter>();
        if (playerCharacter != null)
        {
            print("ENTER if");
            animator.Play("SignsRotation");
            signIsTouched = animator.GetBool("playerComes");
            animator.SetBool("SignsRotation", !signIsTouched);
            
        }
       
    }
}
