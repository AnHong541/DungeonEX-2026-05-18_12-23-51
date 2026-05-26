using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


[CreateAssetMenu(fileName = "new item")]
public class ItemSO : ScriptableObject
{ 
    public string itemName;
    [TextArea] public string itemDescription;
    public Sprite icon;

    public bool isGold;
    public bool isArrow;
    public int stackSize = 10;

    [Header("Stats")]
    public int currentHealth;
    public int maxHealth;
    public int damage;

    [Header("For Temporary Items")]
    public float duration;
}
