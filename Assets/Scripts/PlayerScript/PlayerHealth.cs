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
        healthText.text = "HP: " + StatManager.Instance.CurrentHealth + " / " + StatManager.Instance.MaxHealth;
    }

    public void changeHealth(int ammount) 
    {
        StatManager.Instance.ChangeHealth(ammount);
        healthTextAnim.Play("HPupdate");

        healthText.text = "HP: " + StatManager.Instance.CurrentHealth + " / " + StatManager.Instance.MaxHealth;

        if (StatManager.Instance.CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
