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
        
        _stateMachine.SetState(play);
        _stateMachine.AddTransition(play,end, messager.GameEndConditionMeets);
        _stateMachine.AddTransition(play,pause, ()=>messager.IsPausing);
        _stateMachine.AddTransition(pause,play, ()=>!messager.IsPausing);
    }

    private void Update()
    {
        _stateMachine.Tick();
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
    public void Tick()
    {
        Debug.Log("play ticking");
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