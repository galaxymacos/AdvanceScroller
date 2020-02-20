using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class SkillCooldownManager : MonoBehaviour
{
    public List<Skill> skills;
    private PlayerCharacter playerCharacter;
    
    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    private void Start()
    {
        foreach (Skill skill in skills)
        {
            skill.coolDownCounter = skill.coolDown;
        }
    }

    private void Update()
    {
        foreach (Skill skill in skills)
        {
            if (skill.coolDownCounter > 0)
            {
                skill.coolDownCounter -= Time.deltaTime;
            }
            else
            {
                skill.coolDownCounter = 0;
            }
        }
    }

    // TODO can be optimized
    public bool Use(string skillName)
    {
        foreach (Skill skill in skills)
        {
            if (skill.skillName == skillName)
            {
                
                if (CheckCooldown(skillName))
                {
                    skill.coolDownCounter = skill.coolDown;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    public bool CheckCooldown(string skillName)
    {
        foreach (Skill skill in skills)
        {
            if (skill.skillName == skillName)
            {
                
                if (skill.coolDownCounter <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}