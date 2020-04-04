using System.Linq;
using UnityEngine;

public class GamePauseProcessor: MonoBehaviour
{
    private void Awake()
    {
        GameStateMachine.gamePause += PauseCharacter;
        GameStateMachine.gameUnPause += UnPauseCharacter;
        
    }

    private void OnDestroy()
    {
        GameStateMachine.gamePause -= PauseCharacter;
        GameStateMachine.gameUnPause -= UnPauseCharacter;

    }

    public void PauseCharacter()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.Pause();
        }
    }

    public void UnPauseCharacter()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.UnPause();
        }
    }
}