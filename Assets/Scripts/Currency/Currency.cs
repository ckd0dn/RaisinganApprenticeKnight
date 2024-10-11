using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int gold;     // 게임 재화
    private int crystal;  // 유료 재화

    private CurrencyPanel panel;

    private void Awake()
    {
        panel = FindFirstObjectByType<CurrencyPanel>();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        panel.UpdateCrurrencyUI();
    }

    public void UseGold(int amount)
    {
        if(gold < amount)
        {
            Debug.Log("골드가 부족합니다.");
            return;
        }

        gold -= amount;
        panel.UpdateCrurrencyUI();
    }

    public void AddCrystal(int amount)
    {
        crystal += amount;
        panel.UpdateCrurrencyUI();
    }

    public void UseCrystal(int amount)
    {
        if (crystal < amount)
        {
            Debug.Log("크리스탈이 부족합니다.");
            return;
        }

        crystal -= amount;
        panel.UpdateCrurrencyUI();
    }

    public int GetGold()
    {
        return gold;
    }

    public int GetCrystal()
    {
        return crystal;
    }
}
