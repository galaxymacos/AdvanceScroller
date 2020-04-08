using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditData : MonoBehaviour
{
    public float lastAttackTime;

    public float attackCooldown = 3f;
    public float timePassMultiplierWhenPlayerInRange = 3;
    public float alertTime = 6f;
    public float alertTimeCounter;
    public PlayerCharacter targetPlayer;
    [SerializeField] private Transform jumpingPointsParent;
    public List<Transform> jumpingPoints => jumpingPointsHidden;
    private List<Transform> jumpingPointsHidden;
    public int maxJumpingTime;
    public int jumpingTimeCounter;
    public BanditDataInquirer dataInquirer;
    public BanditData()
    {
        dataInquirer = new BanditDataInquirer(this);
    }

    private void Awake()
    {
        jumpingPointsHidden = new List<Transform>();
        foreach (Transform child in jumpingPointsParent)
        {
            jumpingPointsHidden.Add(child);
        }
    }

    public class BanditDataInquirer
    {
        private BanditData banditData;

        public BanditDataInquirer(BanditData banditData)
        {
            this.banditData = banditData;
        }

        public Transform[] NearJumpingPointsToPosition(Vector3 targetPosition, List<Transform> points, int numberOfPositionToReturn=1)
        {
            float distance = 100000;
            Transform targetTransform = null;
            List<Transform> tempArray = new List<Transform>();
            foreach (Transform point in points)
            {
                tempArray.Add(point);
            }
            
            List<Transform> results = new List<Transform>();

            for (int i = 0; i < numberOfPositionToReturn; i++)
            {
                for (int j = 0; j < tempArray.Count; j++)
                {
                    if(Vector3.Distance(targetPosition, tempArray[j].position)< distance)
                    {
                        targetTransform = tempArray[j];
                        distance = Vector3.Distance(targetPosition, tempArray[j].position);
                    }
                }
                tempArray.Remove(targetTransform);
                results.Add(targetTransform);
            }
            return results.ToArray();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
