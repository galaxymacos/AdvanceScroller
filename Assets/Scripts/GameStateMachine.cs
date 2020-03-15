using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] private GameStateMachineMessager messager;
    
    private void Awake()
    {
        _stateMachine = new StateMachine();

        
    }

    private void Start()
    {
        var play = new Play();
        var pause = new Pause();
        var end = new End();
        var endSlowMotion = new EndSlowMotion();
        
        _stateMachine.SetState(play);
        // _stateMachine.AddTransition(play,end, messager.GameEndConditionMeets);
        _stateMachine.AddTransition(play,endSlowMotion, messager.GameEndConditionMeets);
        _stateMachine.AddTransition(endSlowMotion,end, messager.ShouldTransferToGameEnd);
        _stateMachine.AddTransition(play,pause, ()=>messager.IsPausing);
        _stateMachine.AddTransition(pause,play, ()=>!messager.IsPausing);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }
}

public class EndSlowMotion: IState
{
    private static readonly float slowMotionTime = 3;
    public static float slowMotionTimeCounter = 3;
    public void Tick()
    {
        Time.timeScale = 0.2f;
        if (slowMotionTimeCounter>0)
        {
            slowMotionTimeCounter -= Time.unscaledDeltaTime;
        }
        Debug.Log(slowMotionTimeCounter);
    }

    public void OnEnter()
    {
        slowMotionTimeCounter = slowMotionTime;
        Time.timeScale = 0.2f;
    }

    public void OnExit()
    {
        slowMotionTimeCounter = 3;
        Time.timeScale = 1f;
    }
}

public class End : IState
{
    public static event Action OnGameEnd;
    public void Tick()
    {
    }

    public void OnEnter()
    {
        Debug.Log("Game over");
        OnGameEnd?.Invoke();
    }


    public void OnExit()
    {
    }
}

public class Play : IState
{
    public static event Action OnGameStart;
    public void Tick()
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }
}

public class Pause : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
        var scripts = Object.FindObjectsOfType<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script is IPauseable pauseable)
            {
                pauseable.Pause();
            }
        }
    }

    public void OnExit()
    {
        var scripts = Object.FindObjectsOfType<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script is IPauseable pauseable)
            {
                pauseable.UnPause();
            }
        }
    }
}