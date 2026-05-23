using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    public int expReward = 3;

    public delegate void MonsterDeath(int exp);
    public static event MonsterDeath OnMonsterDeath;

    public int currentHealth;
    public int maxHealth;
    public Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            OnMonsterDeath(expReward);
            Destroy(gameObject);
        }
    }
}
