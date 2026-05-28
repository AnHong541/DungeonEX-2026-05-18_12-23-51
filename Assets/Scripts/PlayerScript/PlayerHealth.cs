using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public Animator healthTextAnim;

    private void Start()
    {
        UpdateHealthUI();
    }

    public void changeHealth(int ammount)
    {
        // Nếu nhân vật đã chết rồi thì không nhận thêm sát thương nữa
        PlayerMovement movement = GetComponent<PlayerMovement>();
        if (movement != null && movement.isDead) return;

        // Trừ/Cộng máu trong StatManager
        StatManager.Instance.ChangeHealth(ammount);

        // Chạy hiệu ứng nháy chữ HP
        if (healthTextAnim != null)
        {
            healthTextAnim.Play("HPupdate");
        }

        // Cập nhật lại chữ hiển thị HP lên màn hình
        UpdateHealthUI();

        // KIỂM TRA ĐIỀU KIỆN CHẾT:
        if (StatManager.Instance.CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + StatManager.Instance.CurrentHealth + " / " + StatManager.Instance.MaxHealth;
        }
    }

    private void Die()
    {
        // Gọi hàm TriggerDeath() bên PlayerMovement để tắt va chạm, dừng vật lý an toàn
        PlayerMovement movement = GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.TriggerDeath();
        }
        else
        {
            // Trường hợp dự phòng nếu không tìm thấy PlayerMovement, tự gọi thẳng GameManager
            if (GameManager.instance != null)
            {
                GameManager.instance.ShowGameOverScreen();
            }
        }
    }
}