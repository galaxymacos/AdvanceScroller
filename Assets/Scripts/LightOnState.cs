public class LightOnState:IState
{
    public void Tick()
    {
        if (LightingManager.instance.lightOffTrigger)
        {
            LightingManager.instance.lightOffTrigger = false;
        }
        
    }

    public void OnEnter()
    {
        if (LightingManager.instance != null)
        {
            LightingManager.instance.lightOnTrigger = false;
            LightingManager.instance.lightOffTrigger = false;
        }
    }

    public void OnExit()
    {
    }
}