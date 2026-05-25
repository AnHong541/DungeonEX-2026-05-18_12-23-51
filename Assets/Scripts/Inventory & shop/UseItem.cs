using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseItem : MonoBehaviour
{
    public void ApplyItemEffect(ItemSO itemSO)
    {
        if (itemSO.currentHealth > 0)
            StatManager.Instance.ChangeHealth(itemSO.currentHealth);
        if (itemSO.maxHealth > 0)
            StatManager.Instance.UpdateMaxHealth(itemSO.maxHealth);
        if (itemSO.damage > 0)
            StatManager.Instance.UpdateDamage(itemSO.damage);

        if (itemSO.duration > 0)
            StartCoroutine(EffectTimer(itemSO, itemSO.duration));
    }


    private IEnumerator EffectTimer(ItemSO itemSO, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (itemSO.currentHealth > 0)
            StatManager.Instance.ChangeHealth(-itemSO.currentHealth);
        if (itemSO.maxHealth > 0)
            StatManager.Instance.UpdateMaxHealth(-itemSO.maxHealth);
        if (itemSO.damage > 0)
            StatManager.Instance.UpdateDamage(-itemSO.damage);
    }
}
