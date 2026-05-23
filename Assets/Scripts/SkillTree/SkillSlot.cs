using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillSlot : MonoBehaviour
{
    public List<SkillSlot> prerequisiteSkillSlots; // List of prerequisite skills that must be unlocked before this skill can be unlocked
    public SkilS0 SkillS0;

    public int currentLevel;
    public bool isUnlocked;

    public Image SkillIcon;
    public Button skillButton;
    public TMP_Text skillLevelText;

    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot> OnSkillMaxed;


    private void OnValidate()
    {
        if (SkillS0 != null && skillLevelText != null)
        {
            UpdateUI();
        }
    }

    public void TryUpgradeSkill()
    {
        if(isUnlocked && currentLevel < SkillS0.maxLevel)
        {
            currentLevel++;
            OnAbilityPointSpent?.Invoke(this);

            if (currentLevel >= SkillS0.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }

            UpdateUI();
        }    
    }

    public bool CanUnlockeSkill()
    {
        foreach (SkillSlot slot in prerequisiteSkillSlots)
        {
            if (!slot.isUnlocked || slot.currentLevel < slot.SkillS0.maxLevel)
            {
                return false; // If any prerequisite skill is not unlocked or not maxed, return false
            }
        }
        return true; 
    }

    public void Unlock()
    {
        isUnlocked = true;
        UpdateUI();
    }


    private void UpdateUI()
    {
        SkillIcon.sprite = SkillS0.skillIcon;
        if (isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = currentLevel.ToString() + "/" + SkillS0.maxLevel.ToString();
            SkillIcon.color = Color.white; // Normal color for unlocked skills
        }
        else
        {
            skillButton.interactable = false;
            skillLevelText.text = "Locked";
            SkillIcon.color = Color.gray; // Dim color for locked skills
        }
    }
}
