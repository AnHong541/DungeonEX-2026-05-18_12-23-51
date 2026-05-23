using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;

    public int quantity;
    public static event Action<ItemSO, int> OnitemPickup;

    private void OnValidate()
    {
        if (itemSO == null)
            return;

        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("pickup");
            OnitemPickup?.Invoke(itemSO, quantity);
            Destroy(gameObject, 0.5f);
        }
    }
}
