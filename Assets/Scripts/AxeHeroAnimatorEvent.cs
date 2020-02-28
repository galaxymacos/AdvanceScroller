using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHeroAnimatorEvent : MonoBehaviour
{
    public GameObject hugeSlashPrefab;
    public Transform particleSpawnTransform;
    public void SpawnHugeSlashParticle()
    {
        Instantiate(hugeSlashPrefab, particleSpawnTransform.position, particleSpawnTransform.rotation);
    }
}
