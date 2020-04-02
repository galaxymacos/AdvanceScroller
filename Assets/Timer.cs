using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer: MonoBehaviour
{
    public UnityEvent onTimerEnd;
    [SerializeField] private float timeToCountdown;
    [SerializeField] private bool awakeLater;
    

    public void StopTimerEarly()
    {
        StopAllCoroutines();
        onTimerEnd?.Invoke();
    }

    private void Start()
    {
        if (!awakeLater)
        {
            StartCoroutine(StartCountdown());
        }
    }

    public void Trigger()
    {
        
        StartCoroutine(StartCountdown());
    }


    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(timeToCountdown);
        onTimerEnd?.Invoke();
    }
}