using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopButtonToggles : MonoBehaviour
{
    public void OpenItemShop()
    {
        if (ShopKeeper.currentShopKeeper != null)
           
            ShopKeeper.currentShopKeeper.OpenItemShop();
    }
    public void OpenArmourShop()
    {
        if (ShopKeeper.currentShopKeeper != null)
            ShopKeeper.currentShopKeeper.OpenArmourShop();
    }
    public void OpenWeaponShop()
    {
        if (ShopKeeper.currentShopKeeper != null)
            ShopKeeper.currentShopKeeper.OpenWeaponShop();
    }
}
