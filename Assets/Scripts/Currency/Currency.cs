using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int gold;     // ���� ��ȭ
    private int crystal;  // ���� ��ȭ

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void UseGold(int amount)
    {
        if(gold < amount)
        {
            Debug.Log("��尡 �����մϴ�.");
            return;
        }

        gold -= amount;
    }

    public void AddCrystal(int amount)
    {
        crystal += amount;
    }

    public void UseCrystal(int amount)
    {
        if (crystal < amount)
        {
            Debug.Log("ũ����Ż�� �����մϴ�.");
            return;
        }

        crystal -= amount;
    }
}
