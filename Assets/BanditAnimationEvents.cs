using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimationEvents : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent attack;

    [SerializeField] private GameObject tennisBall;

    [SerializeField] private Transform tennisBallSpawnLocation;
    // Start is called before the first frame update
    

    public void AnimationEvent_FireAttack()
    {
        attack.Execute();
    }

    public void SpawnTennisBall()
    {
        var tb = Instantiate(tennisBall, tennisBallSpawnLocation.position, Quaternion.identity);
        tb.GetComponent<NewProjectileDamageComponent>().Setup(gameObject);
    }
}
