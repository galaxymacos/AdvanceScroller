using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpritesStorer : MonoBehaviour
{
    [SerializeField] private float timeToRecord = 0.2f;
    private float scanRate = 0.02f;
    private float scanTimeCounter;

    private Queue<HistroyData> historyData;
    
    public SpriteRenderer sr;
    public HistroyData TwosecsAgo;

    public GameObject ultimateShadowPrefab;

    public UltimateBuffTimer ultimateBuffTimer;

    private GameObject ultimateShadow;
    private void InstantiateUltimateShadow()
    {
        print("instantiate ultimate shadow");
        ultimateShadow = Instantiate(ultimateShadowPrefab, transform.position, Quaternion.identity);
        ultimateShadow.GetComponent<CatHeroUltimateShadow>().Setup(this);
    }
    public class HistroyData
    {
        
        public readonly float timeStamp;
        public Vector3 historyPosition;
        public Quaternion historyRotation;
        public Vector3 historyScale;
        public readonly Sprite sprite;

        public HistroyData(float timeStamp, Transform historyTransform, Sprite sprite)
        {
            this.timeStamp = timeStamp;
            this.historyPosition = historyTransform.position;
            this.historyRotation = historyTransform.rotation;
            this.historyScale = historyTransform.localScale;
            this.sprite = sprite;
        }
    }

    public void Update()
    {
        historyData.Enqueue(new HistroyData(Time.time, transform, sr.sprite));

        if (historyData.Count <= 0) return;
        while (historyData.Peek().timeStamp < (Time.time - timeToRecord))
        {
            TwosecsAgo = historyData.Dequeue();
        }
    }
    
    private void Awake()
    {
        scanTimeCounter = scanRate;
        historyData = new Queue<HistroyData>();
        ultimateBuffTimer.onUltimateStart += InstantiateUltimateShadow;
        ultimateBuffTimer.onUltimateEnd += DisposeUltimateShadow;
    }

    private void DisposeUltimateShadow()
    {
        ultimateShadow.GetComponent<CatHeroUltimateShadow>().Dispose();
    }

    private void OnDestroy()
    {
        ultimateBuffTimer.onUltimateStart -= InstantiateUltimateShadow;
        ultimateBuffTimer.onUltimateEnd += DisposeUltimateShadow;
    }
}
