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
    public GameObject lootPrefab;
    public Transform player; 


    private void Start()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
        goldText.text = gold.ToString();
        arrowText.text = arrow.ToString();
    }

    private void Update()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                UseItem(itemSlots[i]);
                break;
            }
        }
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
        foreach (var slot in itemSlots)
        {
            if (quantity <= 0) return;

            if (slot.itemSO == itemSO && slot.quantity < itemSO.stackSize)
            {
                int availableSpace = itemSO.stackSize - slot.quantity;
                int amountToAdd = Mathf.Min(availableSpace, quantity);
                slot.quantity += amountToAdd;
                quantity -= amountToAdd;
                slot.UpdateUI();
            }
        }
        foreach (var slot in itemSlots)
        {
            if (quantity <= 0) return;

            if (slot.itemSO == null)
            {
                int amountToAdd = Mathf.Min(itemSO.stackSize, quantity);
                slot.itemSO = itemSO;
                slot.quantity = amountToAdd;
                quantity -= amountToAdd;
                slot.UpdateUI();
            }
        }
        if (quantity > 0)
        {
            DropLoot(itemSO, quantity);
        }
    }

    public void DropItem(InventorySlot itemSlot)
    {
        DropLoot(itemSlot.itemSO, 1);
        itemSlot.quantity--;
        if(itemSlot.quantity <= 0)
        {
            itemSlot.itemSO = null;
        }
        itemSlot.UpdateUI();
    }


    private void DropLoot(ItemSO itemSO, int quantity)
    {
        Loot loot = Instantiate(lootPrefab, player.position, Quaternion.identity).GetComponent<Loot>();
        loot.Initialized(itemSO, quantity);
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