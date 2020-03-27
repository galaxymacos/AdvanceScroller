using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(GhostStats))]
public class GhostScoreSystem : MonoBehaviour
{
    private Animator anim;
    private List<string> listOfActions;
    private List<Func<int>> ActionScoreCalculators;


    private GhostStats stats;

    private void Awake()
    {
        listOfActions = new List<string> {"chase", "attack", "wander","celebrate"};
        ActionScoreCalculators = new List<Func<int>> {ToChaseCondition, ToAttackCondition, ToWanderCondition, ToCelebrateCondition};
        stats = GetComponent<GhostStats>();
        anim = GetComponent<Animator>();
    }

    public string GetNextAction()
    {
        int totalScore = 0;
        StringBuilder sb = new StringBuilder();
        // List<int> scoreLimit = new List<int>();
        for (int i = 0; i < listOfActions.Count; i++)
        { 
            sb.Append($"{listOfActions[i]} score: {ActionScoreCalculators[i]()}; ");
            totalScore += ActionScoreCalculators[i]();
            // scoreLimit.Add(totalScore);
        }
        print(sb.ToString());

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
        }
        else
        {
            print("Action to play: "+actionToPlay);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(actionToPlay))
        {
            actionToPlay = "";
        }
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

            if (stats.interestPointInChasingCounter <= 0)
            {
                // Debug.LogError("ghost loses interest to player");
                return 0;
            }

            if (Vector3.Distance(transform.position, stats.playerToChase.transform.position) >
                stats.rangeToLoseInterestInChasing)
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
            // print("attack condition doesn't meet 1");
            return 0;
        }

        if (stats.lastAnimationState.IsName("attack"))
        {
            return 100;
        }

        if (Vector3.Distance(stats.playerToChase.transform.position, transform.position) <= stats.attackRange)
        {
            if (Time.time < stats.lastAttackTime+stats.attackCooldown)
            {
                // print("attack condition doesn't meet 2");
                return 0;
            }
            return 100;
        }
        // print("attack condition doesn't meet 3");
        return 0;
    }
    private int ToWanderCondition()
    {
        if (!stats.playerToChase)
        {
            return 100;
        }

        int point = 0;

        if(Vector3.Distance(stats.playerToChase.transform.position, transform.position) <= stats.attackRange)
        {
            point += 0;
        }
        else
        {
            point += 20;
        }
        if (Vector3.Distance(stats.playerToChase.transform.position, transform.position) <=
                 stats.detectPlayerRange)
        {
            point += 10;
        }
        else
        {
            point += 30;
        }

        if (Time.time > stats.lastHitTime + 3f)
        {
            point += 0;
        }
        else
        {
            point += 30;
        }

        return point;

    }

    private int ToCelebrateCondition()
    {
        if (stats.lastAnimationState.IsName("attack"))
        {
            return Mathf.Clamp(stats.attackSucceedNum * stats.scoreToCelebratePerAttack, 0, 100);
        }

        return 0;
    }

    #endregion
    


    private int CalculateScoreBasedOnPlayerDistance()
    {
        return Mathf.Clamp((int) ((1 - Vector3.Distance(stats.playerToChase.transform.position, transform.position) /
            MapInfo.instance.Inquirer.GetLongestDistance()) * 100-20),0,100);
    }

    

    
}