using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMessagerSamurei : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent attack;
    [SerializeField] private ContinuousAttack skill1;
    [SerializeField] private SingleAttackComponent skill2Swing1st;
    [SerializeField] private SingleAttackComponent skill2Swing2nd;
    [SerializeField] private GameObject dragonUltimatePrefab;
    [SerializeField] private Transform dragonUltimateTransform;
    
    
    [SerializeField] private Transform swordQiSpawnTransform;
    [SerializeField] private GameObject SwordQiPrefab;
    
    [SerializeField] private Transform shurikenSpawnTransform;
    [SerializeField] private GameObject ShurikenPrefab;
    

    

    public void AnimationEvent_SpawnShuriken()
    {
        var shuriken = Instantiate(ShurikenPrefab, shurikenSpawnTransform.position, Quaternion.identity);
        shuriken.GetComponent<NewProjectile>().Setup(gameObject,33f);
    }
    
    public void AnimationEvent_SpawnSwordQi()
    {
        var swordQi = Instantiate(SwordQiPrefab, swordQiSpawnTransform.position, Quaternion.identity);
        swordQi.GetComponent<NewProjectile>().Setup(gameObject,20f);
    }

    public void AnimationEvent_Attack()
    {
        attack.Execute();
    }

    public void AnimationEvent_Skill1()
    {
        skill1.Execute();
    }

    public void AnimationEvent_Skill2Swing1()
    {
        skill2Swing1st.Execute();
    }
    
    public void AnimationEvent_Skill2Swing2()
    {
        skill2Swing2nd.Execute();
    }

    public void AnimationEvent_SummonDragon()
    {
        GameObject dragonUltimate = Instantiate(dragonUltimatePrefab,dragonUltimateTransform.position, Quaternion.identity);
        dragonUltimate.GetComponent<NewProjectile>().Setup(gameObject, 15);
        dragonUltimate.GetComponent<UltraSpacePlacer>().Setup(GetComponent<PlayerCharacter>());
    }

}
