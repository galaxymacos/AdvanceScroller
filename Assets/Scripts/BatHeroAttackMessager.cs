using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class BatHeroAttackMessager : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public SingleAttackComponent attackFirstStrike;
    public SingleAttackComponent attackSecondStrike;
    public ContinuousAttack instantKill;
    public SingleAttackComponent closeYourEyes;

    public GameObject blueballPrefab;
    public GameObject kunaiPrefab;

    private Rigidbody2D rb;
    private Vector3 instantKillDirection;
    private float originalY;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void RecordInstantKillVelocity()
    {
        instantKillDirection = rb.velocity;
        originalY = playerCharacter.transform.position.y;
    }

    public void Teleport()
    {
        Vector3 teleportDirection = Vector3.zero;
        if (playerCharacter.isFacingRight)
        {
            teleportDirection += new Vector3(5, 0);
        }
        else
        {
            teleportDirection += new Vector3(-5, 0);
        }

        teleportDirection += instantKillDirection * 0.2f;

        RaycastHit2D hitInfoWall = Physics2D.Raycast(playerCharacter.transform.position,
            Vector3.Normalize(teleportDirection), teleportDirection.magnitude, playerCharacter.whatIsWall);
        
        if (playerCharacter.isGrounded)
        {
            if (playerCharacter.isFacingRight)
            {
                if (hitInfoWall.collider == null)
                {
                    teleportDirection = new Vector3(4, 0)+new Vector3(Vector3.Normalize(instantKillDirection).x,0);
                    playerCharacter.transform.Translate(teleportDirection);
                }
                else
                {
                    playerCharacter.transform.position = hitInfoWall.point + new Vector2(-1f, 0);
                }
            }
            else
            {
                if (hitInfoWall.collider == null)
                {
                    teleportDirection = new Vector3(-4, 0)+new Vector3(Vector3.Normalize(instantKillDirection).x,0);
                    playerCharacter.transform.Translate(teleportDirection);
                }
                else
                {
                    playerCharacter.transform.position = hitInfoWall.point + new Vector2(1f, 0);
                }
            }
        }
        else // Player is on the air
        {
            Vector3 teleportDirectionHorizontal;
            if (playerCharacter.isFacingRight)
            {
                if (hitInfoWall.collider == null)
                {
                    teleportDirectionHorizontal = playerCharacter.transform.position + new Vector3(4, 0)+Vector3.Normalize(instantKillDirection);
                }
                else
                {
                    teleportDirectionHorizontal = hitInfoWall.point + new Vector2(-1f, 0);
                }
            }
            else
            {
                if (hitInfoWall.collider == null)
                {
                    teleportDirectionHorizontal = playerCharacter.transform.position + new Vector3(-4, 0)+Vector3.Normalize(instantKillDirection);
                }
                else
                {
                    teleportDirectionHorizontal = hitInfoWall.point + new Vector2(1f, 0);
                }
            }
            RaycastHit2D hitInfoGround = Physics2D.Raycast(teleportDirectionHorizontal,
                Vector2.down, playerCharacter.transform.position.y - originalY, playerCharacter.whatIsGround);
            if (hitInfoGround.collider == null)
            {
                playerCharacter.transform.position =
                    new Vector2(teleportDirectionHorizontal.x, playerCharacter.transform.position.y);
            }
            else
            {
                playerCharacter.transform.position =
                    new Vector2(teleportDirectionHorizontal.x, hitInfoGround.point.y+2);
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
        GameObject blueball = Instantiate(blueballPrefab, transform.Find("SpawnLocations").Find("BlueBall").position,
            transform.rotation);
        var projectile = blueball.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 20, 0);
    }

    public void SpawnKunai()
    {
        GameObject kunai = Instantiate(kunaiPrefab, transform.Find("SpawnLocations").Find("Kunai").position,
            transform.rotation);
        var projectile = kunai.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 15, 0);
    }

    public void InstantKill()
    {
        instantKill.Execute();
    }

    public void CloseYourEye()
    {
        closeYourEyes.Execute();
        RecordInstantKillVelocity();
    }
}