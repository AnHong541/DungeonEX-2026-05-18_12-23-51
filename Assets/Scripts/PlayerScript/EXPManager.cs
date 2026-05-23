using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

public class EXPManager : MonoBehaviour
{
    public int level;
    public int currentEXP;
    public int exptoLevel = 10;
    public float expGrowthMultiplier = 1.2f;
    public Slider expBar;
    public TMP_Text currentLevelText;

    public static event Action<int> OnLevelUp;


    private void Start()
    {
        UpdateEXPBar();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainEXP(2);
        }
    }

    private void OnEnable()
    {
        EnemyHealth.OnMonsterDeath += GainEXP;
    }

    private void OnDisable()
    {
        EnemyHealth.OnMonsterDeath -= GainEXP;
    }

    public void GainEXP(int amount)
    {
        currentEXP += amount;
        if (currentEXP >= exptoLevel)
        {
            LevelUP();
        }

        UpdateEXPBar();
    }

    private void LevelUP()
    {
        level++;
        currentEXP -= exptoLevel;
        exptoLevel = Mathf.RoundToInt(exptoLevel * expGrowthMultiplier);
        OnLevelUp?.Invoke(1);
    }

    public void UpdateEXPBar()
    {
        expBar.maxValue = exptoLevel;
        expBar.value = currentEXP;
        currentLevelText.text = "Level: " + level;
    }
}
