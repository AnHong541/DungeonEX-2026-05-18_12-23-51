using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class ShopSlot : MonoBehaviour 
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    [SerializeField] private ShopManager shopManager;
    private int price;

    public int Price => price;
    private void Awake()
    {
        if (shopManager == null)
            shopManager = GetComponentInParent<ShopManager>();
    }

    public void Initialized(ItemSO newItemS0, int price)
    {
        itemSO = newItemS0;
        itemImage.sprite = itemSO.icon;
        itemNameText.text = itemSO.itemName;
        this.price = price;
        priceText.text = price.ToString();
    }

    public void OnButtonClicked()
    {
        shopManager.TryBuyItem(itemSO, price);
    }
}
