using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public int facingDirec = 1;

    public Rigidbody2D rb;
    public Animator anim;

    private bool isKnockback;
    private bool isDashing;
    private bool isAttacking;

    public PlayerCombat player_Combat;

    private float dashCooldownTimer;

    private void Update()
    {
        if (Input.GetButtonDown("Slash") && player_Combat.enabled == true)

        {
            player_Combat.Attack();
        }

        if (Input.GetButtonDown("ToggleDash") && dashCooldownTimer <= 0 && !isDashing && !isKnockback && !isAttacking)
        {
            StartCoroutine(DashCoroutine());
        }

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isKnockback == false && isDashing == false && isAttacking == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * StatManager.Instance.Speed;
        }
    }

    void Flip()
    {
        facingDirec *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float StunTime)
    {
        anim.SetBool("isKnockback", true);
        isKnockback = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(StunTime));
    }

    IEnumerator KnockbackCounter(float StunTime)
    {
        yield return new WaitForSeconds(StunTime);
        rb.linearVelocity = Vector2.zero;
        anim.SetBool("isKnockback", false);
        isKnockback = false;
    }

    IEnumerator DashCoroutine()
    {
        isDashing = true;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 dashDirection;
        if (horizontal == 0 && vertical == 0)
        {
            dashDirection = new Vector2(facingDirec, 0);
        }
        else
        {
            dashDirection = new Vector2(horizontal, vertical).normalized;
        }

        rb.linearVelocity = dashDirection * StatManager.Instance.DashSpeed;

        yield return new WaitForSeconds(StatManager.Instance.DashDuration);

        rb.linearVelocity = Vector2.zero;
        isDashing = false;

        dashCooldownTimer = StatManager.Instance.DashCooldown;
    }

    public void SetIsAttacking(bool attacking)
    {
        isAttacking = attacking;
    }
}