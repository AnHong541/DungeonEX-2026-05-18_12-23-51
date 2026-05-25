using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public UseItem useItem;
    public int gold;
    public TMP_Text goldText;
    public int arrow;
    public TMP_Text arrowText;


    private void Start()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
        goldText.text = gold.ToString();
        arrowText.text = arrow.ToString();
    }

    private void OnEnable()
    {
        Loot.OnitemPickup += AddItem;
    }

    private void OnDisable()
    {
        Loot.OnitemPickup -= AddItem;
    }

    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }
        else if (itemSO.isArrow)
        {
            arrow += quantity;
            arrowText.text = arrow.ToString();
            return;
        }
        else
        {
            foreach (var slot in itemSlots)
            {
                if (slot.itemSO == null)
                {
                    slot.itemSO = itemSO;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
            }
        }
    }

    public void UseItem(InventorySlot itemSlot)
    {
        if (itemSlot.itemSO != null && itemSlot.quantity > 0)
        {
            useItem.ApplyItemEffect(itemSlot.itemSO);

            itemSlot.quantity--;
            if (itemSlot.quantity <= 0)
            {
                itemSlot.itemSO = null;
            }
            itemSlot.UpdateUI();
        }
    }
}