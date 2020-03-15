using System;
using UnityEngine;

public class MenuStateMachineMessager: MonoBehaviour
{
    public static MenuStateMachineMessager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        MenuStateMachine.onStateChangedToMapVote += ClearCurrentPointer;
        MenuStateMachine.onSelectionChangeToSelectHero += ClearCurrentPointer;
    }

    private void OnDestroy()
    {
        MenuStateMachine.onStateChangedToMapVote -= ClearCurrentPointer;
        MenuStateMachine.onSelectionChangeToSelectHero -= ClearCurrentPointer;
    }

    private void ClearCurrentPointer()
    {
        PointerCounter.PointerNum = 0;
    }
}