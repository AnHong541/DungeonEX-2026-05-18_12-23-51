using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup StatsCanvas;

    private bool statsOpen = false;

    public void Start()
    {
        UpdateAllStats();
    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text  = "Damage: " + StatManager.Instance.Damage;
    }
    public void UpdateHealth()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Max Health: " + StatManager.Instance.MaxHealth;
    }
    public void UpdateSpeed()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatManager.Instance.Speed;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateHealth();
        UpdateSpeed();
    }
}
