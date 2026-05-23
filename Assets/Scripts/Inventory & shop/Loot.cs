using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loot : MonoBehaviour
{
    public ItemS0 itemS0;
    public SpriteRenderer sr;
    public Animator anim;

    public int quantity;

    private void OnValidate()
    {
        if (itemS0 = null)
            return;

        sr.sprite = itemS0.icon;
        this.name = itemS0.itemName;
    }
}
