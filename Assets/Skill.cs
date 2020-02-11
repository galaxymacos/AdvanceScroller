using System;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "SkillData")]
public class Skill : ScriptableObject
{
    public string skillName;
    public float coolDown;
    public float coolDownCounter;
}