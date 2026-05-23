using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }

    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.SkillS0.skillName;

        switch(skillName)
        {
            case "MaxHealthBoost":
                StatManager.Instance.UpdateMaxHealth(1);
                break;
            case "AttackBoost":
                StatManager.Instance.UpdateDamage(1);
                break;
            case "SpeedBoost":
                StatManager.Instance.UpdateSpeed(1);
                break;
            default:
                Debug.LogWarning("unkow skill: " + skillName);
                break;
        }
    }
}
