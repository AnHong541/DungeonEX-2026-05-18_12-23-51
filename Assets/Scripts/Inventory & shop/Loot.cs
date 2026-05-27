using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Content;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;

    public bool canBePickUp = true;
    public int quantity;
    public static event Action<ItemSO, int> OnitemPickup;

    private void OnValidate()
    {
        if (itemSO == null)
            return;

        UpdateAppearance();
    }

    public void Initialized(ItemSO itemSO, int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
        canBePickUp = false;

        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canBePickUp == true)
        {
            anim.Play("pickup");
            OnitemPickup?.Invoke(itemSO, quantity);
            Destroy(gameObject, 0.3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBePickUp = true;
        }
    }
}
