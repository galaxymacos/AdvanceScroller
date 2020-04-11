using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockChain : MonoBehaviour
{
    public StateMachine _stateMachine;
    public LockChainEventSystem eventSystem;
    private void Awake()
    {
        _stateMachine = new StateMachine();
    }

    private void Start()
    {
        var flyToEnemy = new FlyToEnemy();
        
    }
}

public class LockChainEventSystem : MonoBehaviour
{
    
}

public class FlyToEnemy: IState{
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

public class AttractToOwner:IState
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





