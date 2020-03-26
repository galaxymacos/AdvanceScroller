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
        listOfActions = new List<string> {"chase", "attack", "wander"};
        ActionScoreCalculators = new List<Func<int>> {ToChaseCondition, ToAttackCondition, ToWanderCondition};
        stats = GetComponent<GhostStats>();
    }

    public string GetNextAction()
    {
        int totalScore = 0;
        // List<int> scoreLimit = new List<int>();
        for (int i = 0; i < listOfActions.Count; i++)
        {
            print($"Action: {listOfActions[i]}, score: {ActionScoreCalculators[i]()}");
            totalScore += ActionScoreCalculators[i]();
            // scoreLimit.Add(totalScore);
        }
        print("\n");

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
            Debug.LogError("Current action is " + actionToPlay);
        }
        print("Action to play: "+actionToPlay);
        return actionToPlay;
    }

    #region Condition Checkers

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
    private int ToAttackCondition()
    {
        if (!stats.playerToChase)
        {
            print("attack condition doesn't meet 1");
            return 0;
        }

        if (Vector3.Distance(stats.playerToChase.transform.position, transform.position) <= stats.attackRange)
        {
            if (Time.time < stats.lastAttackTime+stats.attackCooldown)
            {
                print("attack condition doesn't meet 2");
                return 0;
            }
            return 100;
        }
        print("attack condition doesn't meet 3");
        return 0;
    }
    private int ToWanderCondition()
    {
        
        if (!stats.playerToChase)
        {
            return 100;
        }
        else if(Vector3.Distance(stats.playerToChase.transform.position, transform.position) <= stats.attackRange)
        {
            return 0;
        }
        else if (Vector3.Distance(stats.playerToChase.transform.position, transform.position) <=
                 stats.detectPlayerRange)
        {
            return 10;
        }

        return 70;
    }

    #endregion
    


    private int CalculateScoreBasedOnPlayerDistance()
    {
        return Mathf.Clamp((int) ((1 - Vector3.Distance(stats.playerToChase.transform.position, transform.position) /
            MapInfo.instance.Inquirer.GetLongestDistance()) * 100-20),0,100);
    }

    

    
}