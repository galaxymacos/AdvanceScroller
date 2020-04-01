using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTextIndicator : MonoBehaviour
{
    [SerializeField] private Transform textSpawnTransformInWorld;
    private CharacterDamageReceiver chc;
    public void SpawnMissText()
    {
        FloatingTextSpawner.instance.SpawnText("Miss",textSpawnTransformInWorld.position);
    }

    private void SpawnInjuryText(int damage)
    {
        FloatingTextSpawner.instance.SpawnText(damage.ToString(),textSpawnTransformInWorld.position);
    }

    private void Awake()
    {
        chc = GetComponent<CharacterDamageReceiver>();
        chc.onTakeDamage += SpawnInjuryText;
    }

    private void OnDestroy()
    {
        chc.onTakeDamage -= SpawnInjuryText;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
