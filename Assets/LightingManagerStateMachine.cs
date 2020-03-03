using System;
using UnityEngine;

public class LightingManagerStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        LightTurningOffState lightTurningOff = new LightTurningOffState();
        LightTurningOnState lightTurningOn = new LightTurningOnState();
        LightOnState lightOn = new LightOnState();
        LightOffState lightOff = new LightOffState();
        
        _stateMachine.Add(lightTurningOff);
        _stateMachine.Add(lightTurningOn);
        _stateMachine.Add(lightOn);
        _stateMachine.Add(lightOff);
        
        _stateMachine.AddTransition(lightOn, lightTurningOff, ()=>LightingManager.instance.lightOffTrigger);
        _stateMachine.AddTransition(lightOff, lightTurningOn, ()=>LightingManager.instance.lightOnTrigger);
        _stateMachine.AddTransition(lightTurningOn, lightTurningOff, () => LightingManager.instance.lightOffTrigger);
        _stateMachine.AddTransition(lightTurningOff, lightTurningOn, () => LightingManager.instance.lightOnTrigger);



        _stateMachine.SetState(lightOn);
    }
    
    

    private void Update()
    {
        _stateMachine.Tick();
    }
}