using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{

    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
        EXPManager.OnLevelUp += UpdateAbilityPoints;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
        EXPManager.OnLevelUp -= UpdateAbilityPoints;
    }

    private void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(() => CheckAvailablePoints(slot));
        }
        UpdateAbilityPoints(0);
    }

    private void CheckAvailablePoints(SkillSlot slot)
    {
        if (availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }

    private void HandleAbilityPointSpent(SkillSlot skillSlot)
    {
        if (availablePoints > 0)
        {
            UpdateAbilityPoints(-1);
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if (!slot.isUnlocked && slot.CanUnlockeSkill())
            {
                slot.Unlock();
            }
        }
    }

    public void UpdateAbilityPoints(int ammount)
    {
        availablePoints += ammount;
        pointsText.text = "Points: " + availablePoints;
    }
}
