using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint; 
    public LayerMask enemyLayer;
    public StatsUI statsUI;

    public Animator anim;

    public float cooldown = 2;
    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", true);

            timer = cooldown;
        }
    }

    public void Dealdamge()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatManager.Instance.WeaponRange, enemyLayer);

        foreach(Collider2D enemy in enemies)
        {
            if (enemy.isTrigger) continue;

            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(-StatManager.Instance.Damage);
                
            }
            EnemyKnockback enemyKnockback = enemy.GetComponent<EnemyKnockback>();
            if (enemyKnockback != null)
            {
                enemyKnockback.Knockback(StatManager.Instance.transform, StatManager.Instance.KnockbackForce, StatManager.Instance.KnockbackTime, StatManager.Instance.StunTime);
            }
        }
    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null || StatManager.Instance == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, StatManager.Instance.WeaponRange);
    }
}
