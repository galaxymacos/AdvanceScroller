using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class LuckySpin : MonoBehaviour
{
    [SerializeField] private float spinInterval = 0.1f;
    [SerializeField] private float spinIntervalIncreaseTimePerTick = 0.02f;
    [SerializeField] private float waitTime = 3f;
    [SerializeField] private float confirmMapTime = 2f;
    private SpinCandidateData currentSpinCandidate;
    private bool isConfirming;
    private float spinCounter;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        MenuStateMachine.onStateChangedToMapVote += StartSpinning;
        MenuStateMachine.onStateChangedToMapVote += StartCounting;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        MenuStateMachine.onStateChangedToMapVote -= StartSpinning;
        MenuStateMachine.onStateChangedToMapVote -= StartCounting;
    }

    // Update is called once per frame
    void Update()
    {
        if (spinCounter > 0 && !isConfirming)
        {
            spinCounter -= Time.deltaTime;
            if (spinCounter <= 0)
            {
                spinInterval += spinIntervalIncreaseTimePerTick;
                spinCounter = spinInterval;
                SwitchToRandomCandidate();
            }
        }
    }

    public void StartSpinning()
    {
        SwitchToRandomCandidate();
        spinCounter = spinInterval;
    }

    public void SwitchToRandomCandidate()
    {
        currentSpinCandidate = SpinCandidateStorage.instance.GetNextSpinCandidate(currentSpinCandidate);
        GetComponent<SpriteRenderer>().sprite = currentSpinCandidate.sprite;
    }
    

    private void StartCounting()
    {
        StartCoroutine(Counting(waitTime));
    }
    
    private IEnumerator Counting(float sec)
    {
        yield return new WaitForSeconds(sec);

        StartCoroutine(Confirming(confirmMapTime));
        isConfirming = true;
    }

    private IEnumerator Confirming(float sec)
    {
        yield return new WaitForSeconds(sec);
        SaveDataComposer.SetMapIndex(currentSpinCandidate.MapIndex);
        FightData fightData = SaveDataComposer.ToFightData();
        SaveSystem.SaveHeroSelectionData(fightData.SaveToString());
        SceneLoader.LoadFightingMapFromSavedData();
    }
}
