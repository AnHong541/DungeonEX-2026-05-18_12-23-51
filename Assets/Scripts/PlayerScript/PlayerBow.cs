using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public Transform LaunchPoint;
    public GameObject arrowPrefab;
    public InventoryManager inventoryManager;
    public Camera mainCamera;

    private Vector2 aimDirec = Vector2.right;

    public float shootCooldown = 0.5f;
    private float shootTimer;

    public Animator anim;



    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        HandleAiming();
        if (Input.GetButtonDown("Shoot") && shootTimer <= 0)
        {
            if (inventoryManager.arrow > 0)
            {
                anim.SetBool("isShooting", true);
                shootTimer = shootCooldown;
                StartCoroutine(ShootCoroutine());
            }
        }
    }

    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(0);
        anim.SetBool("isShooting", false);
    }

    private void HandleAiming()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(mousePos);

        aimDirec = (worldMousePos - LaunchPoint.position).normalized;
    }

    public void Shoot()
    {
        if (inventoryManager.arrow > 0)
        {
            Arrow arrow = Instantiate(arrowPrefab, LaunchPoint.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = aimDirec;

            inventoryManager.arrow--;
            inventoryManager.arrowText.text = inventoryManager.arrow.ToString();
        }
    }
}