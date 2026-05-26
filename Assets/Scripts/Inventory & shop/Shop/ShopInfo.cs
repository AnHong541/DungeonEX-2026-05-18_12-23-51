using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ShopInfo : MonoBehaviour
{
    public CanvasGroup itemInfo;

    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    [Header("Stat Fields")]
    public TMP_Text[] statTexts;

    private RectTransform itemInfoRect;

    private void Awake()
    {
        itemInfoRect = GetComponent<RectTransform>();
    }

    public void ShowItemInfo(ItemSO itemSO)
    {
        itemInfo.alpha = 1;

        itemNameText.text = itemSO.itemName;
        itemDescriptionText.text = itemSO.itemDescription;

        List<string> stats = new List<string>();
        if (itemSO.currentHealth > 0) stats.Add("Health: " + itemSO.currentHealth.ToString());
        if (itemSO.damage > 0) stats.Add("Damage: " + itemSO.damage.ToString());

        if (stats.Count > 0)
        {
            for (int i = 0; i < statTexts.Length; i++)
            {
                if (i < stats.Count)
                {
                    statTexts[i].text = stats[i];
                    statTexts[i].gameObject.SetActive(true);
                }
                else
                {
                    statTexts[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void HideItemInfo()
    {
        itemInfo.alpha = 0;
        itemNameText.text = "";
        itemDescriptionText.text = "";
    }

    public void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 offset = new Vector3(10, -10, 0);

        itemInfoRect.position = mousePos + offset;
    }
}
