using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimationEvents : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent attack;
    // Start is called before the first frame update
    

    public void AnimationEvent_FireAttack()
    {
        attack.Execute();
    }
}
