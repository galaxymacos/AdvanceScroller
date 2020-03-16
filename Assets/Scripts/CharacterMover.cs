using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Transform moveDestination;

    private void Awake()
    {
        EndScreen.onEndScreenActivate += MoveCharacter;
    }

    private void OnDestroy()
    {
        EndScreen.onEndScreenActivate -= MoveCharacter;
    }

    private void MoveCharacter()
    {
        print("Move character");
        PlayerCharacter winner = FindCharacter();
        WinPose(winner);
        StartCoroutine(MoveToDestination(winner));

    }

    private IEnumerator MoveToDestination(PlayerCharacter player)
    {
        while (Vector3.Distance(moveDestination.position, player.transform.position) > 0.5)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, moveDestination.position, 0.01f);
            yield return null;
        }
        
    }
    
    
    private void WinPose(PlayerCharacter playerCharacter)
    {
        playerCharacter.GetComponent<Animator>().enabled = false;
        playerCharacter.GetComponent<Rigidbody2D>().isKinematic = true;
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        playerCharacter.transform.Find("Character Point Light 2D").GetComponent<Light2D>().intensity *= 2;
        foreach (var playerCollider in playerCharacter.GetComponents<Collider>())
        {
            playerCollider.enabled = false;
        }
        
        playerCharacter.GetComponent<SpriteRenderer>().sprite = playerCharacter.winPose;
    }
    
    

    private PlayerCharacter FindCharacter()
    {
        var playerCharacters = FindObjectsOfType<PlayerCharacter>();
        foreach (var character in playerCharacters)
        {
            if (!character.isDead)
            {
                return character;
            }
        }

        // All players are dead together
        return null;
    }
}
