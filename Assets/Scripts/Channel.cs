using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider2D))]
public class Channel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerCharacter = other.GetComponent<PlayerCharacter>();
        if (playerCharacter != null)
        {
            ChannelEventSystem.instance.PlayerGoIntoChannel(this, playerCharacter);
        }
    }
}