public class PausableSMB: IPauseable
{
    private bool isPausing;

    public bool IsPausing => isPausing;

    private CharacterStateMachineBehavior csmb;
    public PausableSMB(CharacterStateMachineBehavior csmb)
    {
        this.csmb = csmb;
        RegisterPausingEvent();
    }
    
    private void RegisterPausingEvent()
    {
        csmb.playerCharacter.GetComponent<CharacterPauser>().onCharacterPaused += Pause;
        csmb.playerCharacter.GetComponent<CharacterPauser>().onCharacterResumed += UnPause;
    }
    
    public void Pause()
    {
        isPausing = true;
    }

    public void UnPause()
    {
        isPausing = false;
    }
}