using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerSkillPanel : MonoBehaviour
{
    public PlayerCharacter owner;
    public List<Image> skillCooldownIndicators;
    public List<Skill> skills;
    private bool hasSetup;

    public Action onPlayerSetup;
    
    // Start is called before the first frame update
    private void Awake()
    {
        onPlayerSetup += Setup;
    }

    public void Setup()
    {
        hasSetup = true;
        SkillCooldownManager skillManager = owner.GetComponent<SkillCooldownManager>();
        
        foreach (var skill in skillManager.skills)
        {
            switch (skill.skillName)
            {
                case "skill1":
                    
                    skills.Add(skill);
                    break;
                
            }
        }
        
        foreach (var skill in skillManager.skills)
        {
            switch (skill.skillName)
            {
                case "skill2":
                    
                    skills.Add(skill);
                    break;
                
            }
        }
        
        foreach (var skill in skillManager.skills)
        {
            switch (skill.skillName)
            {
                case "skill3":
                    
                    skills.Add(skill);
                    break;
                
            }
        }
        
        foreach (var skill in skillManager.skills)
        {
            switch (skill.skillName)
            {
                case "skill4":
                    
                    skills.Add(skill);
                    break;
                
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSetup) return;

        for (int i = 0; i < skillCooldownIndicators.Count; i++)
        {
            skillCooldownIndicators[i].fillAmount = skills[i].coolDownCounter / skills[i].coolDown;
        }
    }
}
