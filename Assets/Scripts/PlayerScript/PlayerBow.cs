using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerBow : MonoBehaviour
{
    public Transform LaunchPoint;
    public GameObject arrowPrefab;

    private Vector2 aimDirec = Vector2.right;

    public float shootCooldown = 5f;
    private float shootTimer;

    public Animator anim;


    private void Update()
    {
        shootTimer -= Time.deltaTime;

        HandleAiming();
        if (Input.GetButtonDown("Shoot") && shootTimer <= 0)
        {
            anim.SetBool("isShooting", true);
            StartCoroutine(ShootCoroutine());
        }
    }

    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(shootTimer); 
        Shoot();
        anim.SetBool("isShooting", false); 
    }
    private void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            aimDirec = new Vector2(horizontal, vertical).normalized;
        }
    }

    public void Shoot()
    {
        if (shootTimer <= 0)
        {
            Arrow arrow = Instantiate(arrowPrefab, LaunchPoint.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = aimDirec;

            shootTimer = shootCooldown;
        }
    }
}
