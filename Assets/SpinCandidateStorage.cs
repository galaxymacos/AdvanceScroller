using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCandidateStorage : MonoBehaviour
{
    
    private static List<SpinCandidateData> spinCandidates;

    public static List<SpinCandidateData> SpinCandidates => spinCandidates;

    private void Awake()
    {
        spinCandidates = new List<SpinCandidateData>();
        // TODO add click to select map component event 
        ClickToSelectMapComponent.onSelectMapComponent += AddCandadate;
    }

    // Start is called before the first frame update

    private void AddCandadate(ClickToSelectMapComponent clickToSelectMapComponent)
    {
        print("add candidate");
        Sprite mapSprite = clickToSelectMapComponent.GetComponent<SpriteRenderer>().sprite;
        int mapIndex = clickToSelectMapComponent.mapIndex;
        SpinCandidateData candidateData = new SpinCandidateData(mapIndex, mapSprite);
        spinCandidates.Add(candidateData);
    }

    public static SpinCandidateData GetNextSpinCandidate(SpinCandidateData candidateData)
    {
        if (candidateData == null)
        {
            return spinCandidates[0];
        }
        for (int i = 0; i < spinCandidates.Count; i++)
        {
            if (spinCandidates[i] == candidateData)
            {
                if (i == spinCandidates.Count - 1) return spinCandidates[0];
                return spinCandidates[i + 1];
            }
        }

        Debug.LogError("Can't find spin Candidate");
        return null;
    }
}