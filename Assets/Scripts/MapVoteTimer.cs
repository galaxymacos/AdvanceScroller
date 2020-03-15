using System.Collections;
using UnityEngine;

public class MapVoteTimer : MonoBehaviour
{
    private void Awake()
    {
        MenuStateMachine.onStateChangedToMapVote += StartCounting;
    }
    [SerializeField] private float waitTime = 3f;

    private void StartCounting()
    {
        StartCoroutine(Counting(waitTime));
    }
    
    private static IEnumerator Counting(float sec)
    {
        yield return new WaitForSeconds(sec);
        FightData fightData = SaveDataComposer.ToFightData();
        SaveSystem.SaveHeroSelectionData(fightData.SaveToString());
        SceneLoader.LoadFightingMapFromSavedData();
    }
}