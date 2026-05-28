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
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        if (isDead) return;
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        OnMonsterDeath?.Invoke(expReward);

        var movement = GetComponent<EnemyMovement>();
        if (movement != null) movement.enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        anim.SetTrigger("isDeath");

        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitUntil(() =>
            anim.GetCurrentAnimatorStateInfo(0).IsName("Death"));

        float deathAnimLength = anim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(deathAnimLength);

        Destroy(gameObject);
    }
}