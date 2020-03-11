using System;
using UnityEngine;

public class PlayerParticleSpawnerProxy : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;

    private bool spawnWallDust;
    private float wallDustSpawnCounter;
    private float wallDustSpawnInterval = 0.13f;
    private void Awake()
    {
        if (playerCharacter == null)
        {
            playerCharacter = GetComponent<PlayerCharacter>();
        }

        playerCharacter.onFacingDirectionChanged += SpawnGroundDustGroundLimited;
        playerCharacter.onPlayerStartDash += SpawnGroundDust;
        playerCharacter.onPlayerStartMove += SpawnGroundDustGroundLimited;
        playerCharacter.onPlayerStartJump += SpawnGroundDustTwoWays;
        playerCharacter.onPlayerStartDoubleJump += SpawnGroundDustTwoWays;
        playerCharacter.onPlayerGrounded += SpawnGroundDustTwoWays;
        playerCharacter.onPlayerDodgeSucceed += () => ShadowFactory.instance.CreatedissolveShadow(playerCharacter);

        playerCharacter.onPlayerStartWallSlide += StartSpawningWallSlideDust;
        playerCharacter.onPlayerStopWallSlide += StopSpawningWallSlideDust;
    }

    private void Update()
    {
        if (spawnWallDust)
        {
            if (wallDustSpawnCounter > 0)
            {
                wallDustSpawnCounter -= Time.deltaTime;
                if (wallDustSpawnCounter <= 0)
                {
                    var gameObject = Instantiate(ParticleSpawner.Instance.WallSlideDust, transform.position, Quaternion.identity);
                    gameObject.transform.localScale = playerCharacter.transform.localScale;
                    wallDustSpawnCounter = wallDustSpawnInterval;
                }
            }

        }
    }

    public void SpawnGroundDustGroundLimited()
    {
        if (playerCharacter.isGrounded)
        {
            SpawnGroundDust();
        }
    }

    public void SpawnGroundDust()
    {
        ParticleSpawner.Instance.SpawnPlayerParticle(ParticleSpawner.Instance.GroundDust, playerCharacter);
    }

    public void SpawnGroundDustTwoWays()
    {
        ParticleSpawner.Instance.SpawnPlayerParticle(ParticleSpawner.Instance.GroundDustTwoWays, playerCharacter);


    }
    
    public void SpawnDieParticle()
    {
        ParticleSpawner.Instance.SpawnPlayerParticle(ParticleSpawner.Instance.DieDust,playerCharacter);
    }

    public void SpawnDodgeShadow()
    {
        Transform currentTransform = transform;
        Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
        GameObject dodgeShadow = Instantiate(ParticleSpawner.Instance.DodgeShadow, currentTransform.position, currentTransform.rotation);
        dodgeShadow.transform.localScale = transform.localScale;
        dodgeShadow.GetComponent<SpriteRenderer>().sprite = currentSprite;
    }
    
   

    public void StartSpawningWallSlideDust()
    {
        wallDustSpawnCounter = wallDustSpawnInterval;
        spawnWallDust = true;
    }

    public void StopSpawningWallSlideDust()
    {
        spawnWallDust = false;
    }
}