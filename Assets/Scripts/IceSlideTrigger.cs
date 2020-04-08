using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlideTrigger : MonoBehaviour
{
    private bool hasStarted;
    
    public PlayerCharacter Owner => owner;
    private PlayerCharacter owner;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasStarted) return;

        var playerCharacter = other.gameObject.GetComponent<PlayerCharacter>();
        if (playerCharacter!=null)
        {
            hasStarted = true;
            owner = playerCharacter;
            IceSlideEventSystem.instance.IceSlideStart();
        }
    }
}
