using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunComponent : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public float stunTimeCounter;

    public Action onstunEnd;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (stunTimeCounter > 0)
        {
            stunTimeCounter -= Time.deltaTime;
            if (stunTimeCounter <= 0)
            {
                onstunEnd?.Invoke();
            }
        }
    }

    public void SetStunTime(float newStunTime)
    {
        if (newStunTime > 0)
        {
            stunTimeCounter = newStunTime;
            playerCharacter.GetComponent<Animator>().SetTrigger("hit stun");
        }
    }
}
