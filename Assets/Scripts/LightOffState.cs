public class LightOffState:IState
{
    public void Tick()
    {
        if (LightingManager.instance.lightOnTrigger)
        {
            LightingManager.instance.lightOnTrigger = false;
            // Transfer to LightTurningOnState
        }
    }

    public void OnEnter()
    {
        LightingManager.instance.lightOnTrigger = false;
        LightingManager.instance.lightOffTrigger = false;
        
        LightingManager.instance.hasLightFullyRecovered = false;
    }

    public void OnExit()
    {
    }
}