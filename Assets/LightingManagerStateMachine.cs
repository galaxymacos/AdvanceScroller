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
        
        _stateMachine.AddAnyTransition(lightTurningOff,()=>LightingManager.instance.lightOffTrigger);
        _stateMachine.AddAnyTransition(lightTurningOn,()=>LightingManager.instance.lightOnTrigger);
        _stateMachine.AddTransition(lightTurningOn, lightOn, () => LightingManager.instance.hasLightFullyRecovered);
        _stateMachine.AddTransition(lightTurningOff, lightOff, () => lightTurningOff.HasLightTurnedOff);

        _stateMachine.SetState(lightOn);
    }
    
    

    private void Update()
    {
        _stateMachine.Tick();
    }
}