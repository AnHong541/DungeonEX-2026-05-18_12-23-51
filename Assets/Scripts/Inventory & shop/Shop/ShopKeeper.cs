using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public static ShopKeeper currentShopKeeper;

    public Animator anim;
    public CanvasGroup shopCanvasGroup;
    public ShopManager ShopManager;

    [SerializeField] private List<ShopItems> shopItems;
    [SerializeField] private List<ShopItems> shopArmour;
    [SerializeField] private List<ShopItems> shopWeapons;

    [SerializeField] private Camera shopkeeperCam;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -1);

    public static event Action<ShopManager, bool> OnShopStateChanged;
    private bool playerInRange;
    private bool shopOpen;

    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Interact"))
        {
            if (!shopOpen)
            {
                Time.timeScale = 0;
                currentShopKeeper = this;
                shopOpen = true;
                OnShopStateChanged?.Invoke(ShopManager, true);
                shopCanvasGroup.alpha = 1;
                shopCanvasGroup.interactable = true;
                shopCanvasGroup.blocksRaycasts = true;

                shopkeeperCam.transform.position = transform.position + cameraOffset;
                shopkeeperCam.gameObject.SetActive(true);

                OpenItemShop();
            }
            else
            {
                Time.timeScale = 1;
                currentShopKeeper = null;
                shopOpen = false;
                OnShopStateChanged?.Invoke(ShopManager, false);
                shopCanvasGroup.alpha = 0;
                shopCanvasGroup.interactable = false;
                shopCanvasGroup.blocksRaycasts = false;

                shopkeeperCam.gameObject.SetActive(false);
            }
        }
    }

    public void OpenItemShop()
    {
        ShopManager.PopularShopItem(shopItems);
    }

    public void OpenArmourShop()
    {
        ShopManager.PopularShopItem(shopArmour);
    }

    public void OpenWeaponShop()
    {
        ShopManager.PopularShopItem(shopWeapons);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("playerInRange", true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("playerInRange", false);
            playerInRange = false;
        }
    }
}
