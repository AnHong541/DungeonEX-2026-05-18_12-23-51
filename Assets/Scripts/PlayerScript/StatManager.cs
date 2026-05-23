using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;

    [Header("Player Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = $"HP: {currentHealth} / {maxHealth}";
    }
    public void UpdateDamage(int amount)
    {
        damage += amount;
        damageText.text = $"Damage: {damage}";
    }
    public void UpdateSpeed(int amount)
    {
        speed += amount;
        speedText.text = $"Speed: {speed}";
    }
}
