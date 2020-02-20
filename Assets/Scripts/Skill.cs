using System;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "SkillData")]
public class Skill : ScriptableObject
{
    [Tooltip("Must match the animation name in the animator")]
    public string skillName;
    public float coolDown;
    public float coolDownCounter;
    public Sprite spriteInCooldownPanel;


}