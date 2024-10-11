using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    // ���� 
    [Header("����")]
    public int hpLevel;
    public int atkLevel;
    public int criticalChancePercentLevel;
    public int criticalDamagePercentLevel;
    public int totalDamagePercentLevel;

    // ������ (�� ���׷��̵� �� �����ϴ� ��ġ)
    [Header("������")]
    public float hpIncreaseAmount;
    public float atkIncreaseAmount;
    public float criticalChancePercentIncreaseAmount;
    public float criticalDamagePercentIncreaseAmount;
    public float totalDamagePercentIncreaseAmount;

    // ���� (���׷��̵� �� ���)
    [Header("����")]
    public int hpUpgradeCost;
    public int atkUpgradeCost;
    public int criticalChancePercentUpgradeCost;
    public int criticalDamagePercentUpgradeCost;
    public int totalDamagePercentUpgradeCost;

    // ������ ��ġ (�⺻ �� + ���׷��̵�� ���� ������ ��)
    [Header("������ ��ġ")]
    public float currentHp;
    public float currentAtk;
    [Range(0, 1)] public float currentCriticalChancePercent;
    public float currentCriticalDamagePercent;
    public float currentTotalDamagePercent;

}
