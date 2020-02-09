using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeManager : MonoBehaviour
{
    public static BulletTimeManager instance;

    [SerializeField] private float maxBulletTime = 0.4f;

    private float bulletTimeCounter;
    public float bulletTime;
    private bool isBulletTimeRunning;


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
    }

    private void Update()
    {
        if (isBulletTimeRunning)
        {
            bulletTimeCounter += Time.unscaledDeltaTime;
            if (bulletTimeCounter >= bulletTime)
            {
                isBulletTimeRunning = false;
                Time.timeScale = 1;
                bulletTimeCounter = 0;
            }
        }
    }

    public void Register(float _bulletTime)
    {
        bulletTime = _bulletTime;
        bulletTimeCounter = 0;
        Time.timeScale = 0.01f;
        isBulletTimeRunning = true;
    }
}
