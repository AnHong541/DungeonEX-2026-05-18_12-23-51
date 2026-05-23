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
        healthText.text = "HP: " + StatManager.Instance.currentHealth + " / " + StatManager.Instance.maxHealth;
    }

    public void changeHealth(int ammount) 
    {
        StatManager.Instance.currentHealth += ammount;
        healthTextAnim.Play("HPupdate");

        healthText.text = "HP: " + StatManager.Instance.currentHealth + " / " + StatManager.Instance.maxHealth;

        if (StatManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
