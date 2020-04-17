using UnityEngine;

public class BuffEventRegister: MonoBehaviour
{
    private PlayerPanel playerPanel;
    private bool hasSetuped;
    public BuffUnityEvent electrify;
    public BuffUnityEvent bleed;

    private void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += Setup;
    }
    private void Setup()
    {
        playerPanel.player.GetComponentInChildren<ElectrificationEffectProcessor>().onElectrification += RaiseUnityEvent;
        playerPanel.player.GetComponentInChildren<BleedingEffectProcessor>().onStartBleedingEvent += RaiseBleedEvent;
        hasSetuped = true;
    }


    private void OnDestroy()
    {
        if (hasSetuped)
        { 
            playerPanel.player.GetComponentInChildren<ElectrificationEffectProcessor>().onElectrification -= RaiseUnityEvent;
            playerPanel.player.GetComponentInChildren<BleedingEffectProcessor>().onStartBleedingEvent -= RaiseBleedEvent;
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