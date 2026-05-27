using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesCombat : MonoBehaviour 
{
    public int damage = 1;
    public Transform attackpoint;
    public float weaponRange;
    public LayerMask playerLayer;
    public float knockbackForce;
    public float stunTime;
    public Animator anim;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackpoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            
            hits[0].GetComponent<PlayerHealth>().changeHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
        }
    }
}
