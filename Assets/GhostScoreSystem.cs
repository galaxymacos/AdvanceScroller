using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(GhostStats))]
public class GhostScoreSystem : MonoBehaviour
{
    private List<string> listOfActions;
    private List<Func<int>> ActionScoreCalculators;

    
    private GhostStats stats;

    private void Awake()
    {
        listOfActions = new List<string> {"chase", "attack","wander"};
        ActionScoreCalculators = new List<Func<int>> {ToChaseCondition, ToAttackCondition,ToWanderCondition};
        stats = GetComponent<GhostStats>();
    }
    
    public string GetNextAction()
    {
        int totalScore = 0;
        List<int> scoreLimit = new List<int>();
        for (int i = 0; i < listOfActions.Count; i++)
        {
            totalScore += ActionScoreCalculators[i]();
            scoreLimit.Add(totalScore);
        }
        int randomPoint = Random.Range(0, totalScore);

        
        string actionToPlay = "";
        int score = 0;
        for (int i = 0; i < listOfActions.Count; i++)
        {
            score += ActionScoreCalculators[i]();
            if (score > randomPoint)
            {
                actionToPlay = listOfActions[i];
                break;
            }
        }

        if (string.IsNullOrEmpty(actionToPlay))
        {
            Debug.LogError("Current action is "+actionToPlay);
        }

        return actionToPlay;
    }

    private int ToChaseCondition()
    {
        if (stats.playerToChase)
        {
            if (Vector3.Distance(stats.playerToChase.transform.position, transform.position) <= stats.attackRange)
            {
                return 0;
            }
            else
            {
                return CalculateScoreBasedOnPlayerDistance();
            }
        }
        else
        {
            return 0;
        }
    }

    
    private int CalculateScoreBasedOnPlayerDistance()
    {
        return (int) ((1 - Vector3.Distance(stats.playerToChase.transform.position, transform.position) /
            MapInfo.instance.Inquirer.GetLongestDistance()) * 100);
    }

    private int ToAttackCondition()
    {
        if (!stats.playerToChase)
        {
            return 0;
        }

        if (Vector3.Distance(stats.playerToChase.transform.position, transform.position) <= stats.attackRange)
        {
            return 100;
        }

        return 0;
    }

    private int ToWanderCondition()
    {
        if (!stats.playerToChase)
        {
            return 100;
        }
        else
        {
            return 0;
        }
    }
}