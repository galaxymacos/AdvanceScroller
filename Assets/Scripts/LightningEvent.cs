using System;
using UnityEngine;

public class LightningEvent : RandomEvent
{
    public GameObject lightning;

    public static event Action onThunderHappened;
    public event Action onLightingHappened;
    
    [Tooltip("The interval between thunder and lightning")]
    public float delay = 2;
    private float delayCounter;

    private void Awake()
    {
        onThunderHappened += ThunderSound;
        onLightingHappened += SpawnLightning;
        
    }

    private void OnDestroy()
    {
        onThunderHappened -= ThunderSound;
        onLightingHappened -= SpawnLightning;
    }

    public override void Execute()
    {
        delayCounter = delay;
        onThunderHappened?.Invoke();
    }
    


    protected override void Update()
    {
        base.Update();
        if (delayCounter > 0)
        {
            delayCounter -= Time.deltaTime;
            if (delayCounter <= 0)
            {
                onLightingHappened?.Invoke();
            }
        }
    }

    private void SpawnLightning()
    {

        Vector3 spawnPosition =
            MapInfo.instance.RandomLouTianPosition();
        Instantiate(lightning, spawnPosition, Quaternion.identity);

    }

    private void ThunderSound()
    {
        InfiniteSoundPlayer.instance.PlayAudio(AudioType.Thunder);
    }
    
}