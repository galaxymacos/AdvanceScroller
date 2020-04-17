using UnityEngine;

public class BuffEventRegister: MonoBehaviour
{
    private PlayerPanel playerPanel;
    private bool hasSetuped;
    public BuffUnityEvent electrify;
    public BuffUnityEvent bleed;
    public BuffUnityEvent slow;
    public BuffUnityEvent freeze;

    private void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += Setup;
    }
    private void Setup()
    {
        playerPanel.player.GetComponentInChildren<ElectrificationEffectProcessor>().onElectrification += RaiseUnityEvent;
        playerPanel.player.GetComponentInChildren<BleedingEffectProcessor>().onStartBleedingEvent += RaiseBleedEvent;
        playerPanel.player.GetComponentInChildren<SlowEffectProcessor>().onSlow += RaiseSlowEvent;
        playerPanel.player.GetComponentInChildren<FrozenEffectProcessor>().onFreeze+=RaiseFreezeEvent;
        hasSetuped = true;
    }

    private void RaiseFreezeEvent(object sender, BuffEventArgs e)
    {
        freeze.Invoke(sender, e);
    }

    private void RaiseSlowEvent(object sender, BuffEventArgs e)
    {
        slow?.Invoke(sender,e);
    }
    
    


    private void OnDestroy()
    {
        if (hasSetuped)
        { 
            playerPanel.player.GetComponentInChildren<ElectrificationEffectProcessor>().onElectrification -= RaiseUnityEvent;
            playerPanel.player.GetComponentInChildren<BleedingEffectProcessor>().onStartBleedingEvent -= RaiseBleedEvent;
            playerPanel.player.GetComponentInChildren<SlowEffectProcessor>().onSlow -= RaiseSlowEvent;
            playerPanel.player.GetComponentInChildren<FrozenEffectProcessor>().onFreeze -= RaiseFreezeEvent;
            playerPanel.onPlayerSetupFinish -= Setup;
        }

    }

    private void RaiseUnityEvent(object sender, BuffEventArgs buffEventArgs)
    {
        electrify?.Invoke(sender, buffEventArgs);
    }
    
    private void RaiseBleedEvent(object sender, BuffEventArgs e)
    {
        bleed?.Invoke(sender, e);
    }

}