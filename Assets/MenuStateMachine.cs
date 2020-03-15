using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    public static MenuState state;

    public static Action onSelectionChangeToSelectHero;
    public static Action onStateChangingToMap;
    public static Action onStateChangedToMap;
    public static Action onStateChangedToMapVote;
    private void Awake()
    {
        state = MenuState.SelectHero;
        onSelectionChangeToSelectHero?.Invoke();
    }

    public static void OnStateChange(MenuState newState)
    {
        if (newState == MenuState.SelectMap)
        {
            state = newState;
            onStateChangingToMap?.Invoke();
            print("state changing to map");
            onStateChangedToMap?.Invoke();
            print("state changed to map");
        }
        else if (newState == MenuState.MapVote)
        {
            onStateChangedToMapVote?.Invoke();
        }
    }
    
}

public enum MenuState{SelectHero, SelectMap, MapVote}