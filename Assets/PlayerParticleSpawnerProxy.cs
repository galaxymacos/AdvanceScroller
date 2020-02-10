using UnityEngine;

public class PlayerParticleSpawnerProxy : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;

    private void Awake()
    {
        if (playerCharacter == null)
        {
            playerCharacter = GetComponent<PlayerCharacter>();
        }

        playerCharacter.onFacingDirectionChanged += SpawnGroundDust;
        playerCharacter.onPlayerStartDash += SpawnGroundDust;
        playerCharacter.onPlayerStartJump += SpawnGroundDustTwoWays;
        playerCharacter.onPlayerStartDoubleJump += SpawnGroundDustTwoWays;
        playerCharacter.onPlayerGrounded += SpawnGroundDustTwoWays;
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
}