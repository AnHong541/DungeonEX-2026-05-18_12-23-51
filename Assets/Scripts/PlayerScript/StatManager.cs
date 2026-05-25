using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text speedText;


    [Header("Player Stats")]
    [SerializeField] private int damage;
    [SerializeField] private float weaponRange;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    [SerializeField] private float stunTime;

    [Header("Movement Stats")]
    [SerializeField] private int speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;

    [Header("Health Stats")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    // Min/Max constraints
    private const int MIN_DAMAGE = 1;
    private const int MAX_DAMAGE = 999;
    private const int MIN_SPEED = 1;
    private const int MAX_SPEED = 50;
    private const int MIN_HEALTH = 1;
    private const int MAX_HEALTH = 9999;

    public int Damage => damage;
    public float WeaponRange => weaponRange;
    public float KnockbackForce => knockbackForce;
    public float KnockbackTime => knockbackTime;
    public float StunTime => stunTime;
    public int Speed => speed;
    public float DashSpeed => dashSpeed;
    public float DashDuration => dashDuration;
    public float DashCooldown => dashCooldown;
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    private StatsUI statsUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        statsUI = FindAnyObjectByType<StatsUI>();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

  
    private void SyncStatsUI()
    {
        if (statsUI == null)
            statsUI = FindAnyObjectByType<StatsUI>();
        statsUI?.UpdateAllStats();
    }

    public void UpdateMaxHealth(int amount)
    {
        if (amount == 0) return;
        int newMaxHealth = maxHealth + amount;
        maxHealth = Mathf.Clamp(newMaxHealth, MIN_HEALTH, MAX_HEALTH);

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthDisplay();
        SyncStatsUI();
    }

    public void UpdateDamage(int amount)
    {
        if (amount == 0) return;
        int newDamage = damage + amount;
        damage = Mathf.Clamp(newDamage, MIN_DAMAGE, MAX_DAMAGE);
        UpdateDamageDisplay();
        SyncStatsUI();
    }

    public void UpdateSpeed(int amount)
    {
        if (amount == 0) return;
        int newSpeed = speed + amount;
        speed = Mathf.Clamp(newSpeed, MIN_SPEED, MAX_SPEED);
        UpdateSpeedDisplay();
        SyncStatsUI();
    }

    public void ChangeHealth(int amount)
    {
        if (amount == 0) return;
        int newHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
        UpdateHealthDisplay();
    }

    public void ResetStats()
    {
        damage = 10;
        speed = 5;
        maxHealth = 100;
        currentHealth = 100;
        UpdateHealthDisplay();
        UpdateDamageDisplay();
        UpdateSpeedDisplay();
        SyncStatsUI();
    }

    private void UpdateHealthDisplay()
    {
        if (healthText != null)
            healthText.text = $"HP: {currentHealth} / {maxHealth}";
    }

    private void UpdateDamageDisplay()
    {
        if (damageText != null)
            damageText.text = $"Damage: {damage}";
    }

    private void UpdateSpeedDisplay()
    {
        if (speedText != null)
            speedText.text = $"Speed: {speed}";
    }
}