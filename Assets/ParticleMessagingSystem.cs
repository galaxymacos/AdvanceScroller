using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMessagingSystem : MonoBehaviour
{
    public void SpawnDieParticle()
    {
        ParticleSpawner.Instance.SpawnPlayerParticle(ParticleSpawner.Instance.playerDieDust,GetComponent<PlayerCharacter>());
    }
}
