using System;
using System.Collections;
using Sprites;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;
    private static GameStateMachine instance;

    public static bool gameIsPause;
    private static bool gameWasPause;
    public static event Action gamePause;
    public static event Action gameUnPause;
    

    [SerializeField] private GameStateMachineMessager messager;
    
    private void Awake()
    {
        _stateMachine = new StateMachine();
        if (instance == null)
        {
            instance = this;
        }

    }

    private void Start()
    {
        var play = new Play();
        var pause = new Pause();
        var end = new End();
        var endSlowMotion = new EndSlowMotion();
        
        _stateMachine.SetState(play);
        // _stateMachine.AddTransition(play,end, messager.GameEndConditionMeets);
        if (!OnePlayerTest.IsInDebugMode)
        {
            _stateMachine.AddTransition(play,endSlowMotion, messager.GameEndConditionMeets);
            _stateMachine.AddTransition(endSlowMotion,end, messager.ShouldTransferToGameEnd);
        }
        
        _stateMachine.AddTransition(play,pause, ()=>messager.IsPausing);
        _stateMachine.AddTransition(pause,play, ()=>!messager.IsPausing);
    }

    private void Update()
    {
        UpdateGamePause();

        _stateMachine.Tick();
    }
    
    

    private static void UpdateGamePause()
    {
        if (gameWasPause)
        {
            if (!gameIsPause)
            {
                gameUnPause?.Invoke();
            }
        }
        else if (!gameWasPause)
        {
            if (gameIsPause)
            {
                gamePause?.Invoke();
            }
        }

        gameWasPause = gameIsPause;
    }
}



// Game State
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
    public static event Action onGameEnd;
    public void Tick()
    {
    }

    public void OnEnter()
    {
        onGameEnd?.Invoke();
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
        OnGameStart?.Invoke();
    }

    public void OnExit()
    {
    }
}
public class Pause : IState
{
    public static event Action onPause;
    public static event Action onUnpause;
    public void Tick()
    {
    }

    public void OnEnter()
    {
        onPause?.Invoke();
        // var scripts = Object.FindObjectsOfType<MonoBehaviour>();
        // foreach (var script in scripts)
        // {
        //     if (script is IPauseable pauseable)
        //     {
        //         pauseable.Pause();
        //     }
        // }
    }

    public void OnExit()
    {
        onUnpause?.Invoke();
        // var scripts = Object.FindObjectsOfType<MonoBehaviour>();
        // foreach (var script in scripts)
        // {
        //     if (script is IPauseable pauseable)
        //     {
        //         pauseable.UnPause();
        //     }
        // }
    }
}