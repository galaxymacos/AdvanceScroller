using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        var menu = new Menu();
        var loading = new LoadLevel();
        var play = new Play();
        var pause = new Pause();
        
        _stateMachine.SetState(loading);
    }
}

public class Menu : IState
{
    public void Tick()
    {
        throw new NotImplementedException();
    }

    public void OnEnter()
    {
        throw new NotImplementedException();
    }

    public void OnExit()
    {
        throw new NotImplementedException();
    }
}

public class Play : IState
{
    public void Tick()
    {
        throw new NotImplementedException();
    }

    public void OnEnter()
    {
        throw new NotImplementedException();
    }

    public void OnExit()
    {
        throw new NotImplementedException();
    }
}

public class Pause : IState
{
    public void Tick()
    {
        throw new NotImplementedException();
    }

    public void OnEnter()
    {
        throw new NotImplementedException();
    }

    public void OnExit()
    {
        throw new NotImplementedException();
    }
}

public class LoadLevel : IState
{
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
