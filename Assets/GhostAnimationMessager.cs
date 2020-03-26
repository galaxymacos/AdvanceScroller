using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationMessager : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent attackComponent;

    public void Attack()
    {
        attackComponent.Execute();
    }
}
