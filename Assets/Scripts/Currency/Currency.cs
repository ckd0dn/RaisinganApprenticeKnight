using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int gold;     // ���� ��ȭ
    private int crystal;  // ���� ��ȭ

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
            Debug.Log("��尡 �����մϴ�.");
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
            Debug.Log("ũ����Ż�� �����մϴ�.");
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
