using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer: MonoBehaviour
{
    public UnityEvent onTimerEnd;
    [SerializeField] private float time;

    public void StopTimerEarly()
    {
        StopAllCoroutines();
        onTimerEnd?.Invoke();
    }

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }


    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(time);
        onTimerEnd?.Invoke();
    }
}