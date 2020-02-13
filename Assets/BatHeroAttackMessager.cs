using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class BatHeroAttackMessager : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public SingleAttackComponent attackFirstStrike;
    public SingleAttackComponent attackSecondStrike;
    public ContinuousAttack instantKill;
    public ContinuousAttack closeYourEyes;

    public GameObject blueballPrefab;
    public GameObject kunaiPrefab;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }
    
    


    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Teleport()
    {
        if (playerCharacter.isGrounded)
        {
            if (playerCharacter.isFacingRight)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(playerCharacter.transform.position, Vector2.right, 5, playerCharacter.whatIsWall);
                if (hitInfo.collider != null)
                {
                    playerCharacter.transform.position = hitInfo.transform.position;
                }
                else
                {
                    playerCharacter.transform.Translate(new Vector2(5,0));

                }
            }
            else
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(playerCharacter.transform.position, Vector2.left, 5, playerCharacter.whatIsWall);
                if (hitInfo.collider != null)
                {
                    playerCharacter.transform.position = hitInfo.transform.position;
                }
                else
                {
                    playerCharacter.transform.Translate(new Vector2(-5,0));

                }

            }
            
        }
    }

    public void AttackFirstHit()
    {
        attackFirstStrike.Execute();
    }

    public void AttackSecondHit()
    {
        attackSecondStrike.Execute();
    }

    public void SpawnBlueBall()
    {
        GameObject blueball = Instantiate(blueballPrefab, transform.Find("SpawnLocations").Find("BlueBall").position, transform.rotation);
        var projectile = blueball.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 20 ,0);
    }

    public void SpawnKunai()
    {
        GameObject kunai = Instantiate(kunaiPrefab, transform.Find("SpawnLocations").Find("Kunai").position, transform.rotation);
        var projectile = kunai.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 15 ,0);
    }

    public void InstantKill()
    {
        instantKill.Execute();
    }

    public void CloseYourEye()
    {
        closeYourEyes.Execute();
    }
    
    
}
