using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSkill", menuName = "SkillTree/Skill")]
public class SkilS0 : ScriptableObject
{
    public string skillName;
    public int maxLevel;
    public Sprite skillIcon;
}
