using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPauser : MonoBehaviour, IPauseable
{
    private Rigidbody2D rb;
    private PlayerCharacter playerCharacter;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCharacter = GetComponent<PlayerCharacter>();
        animator = GetComponent<Animator>();
    }

    public void Pause()
    {
        print($"Pause {playerCharacter.gameObject.name}");
        animator.speed = 0f;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }

    public void UnPause()
    {
        animator.speed = 1f;
        print("UnPause");
        rb.isKinematic = false;
    }
}
