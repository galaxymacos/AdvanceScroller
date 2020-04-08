using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallTimer : MonoBehaviour
{
    public bool IsTimeOut=>timerCounter<=0;
    [SerializeField] private float timer = 5f;
    private float timerCounter;
    public event Action onTimeOut;
    
    public TennisBallDamageReceiver tennisBallDamageReceiver;
    // Start is called before the first frame update
    void Awake()
    {
        tennisBallDamageReceiver = GetComponent<TennisBallDamageReceiver>();
        tennisBallDamageReceiver.onTennisBallTakeDamage += SetBallOnFire;
    }

    private void OnDestroy()
    {
        tennisBallDamageReceiver.onTennisBallTakeDamage -= SetBallOnFire;
    }

    private void SetBallOnFire()
    {
        timerCounter = timer;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (timerCounter>0)
        {
            timerCounter -= Time.deltaTime;
            if (timerCounter <= 0)
            {
                GetComponent<NewProjectileDamageComponent>().Expired = true;
                onTimeOut?.Invoke();
            }
        }
    }

    
}
