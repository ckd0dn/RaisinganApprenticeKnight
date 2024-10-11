using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    // 레벨 
    [Header("레벨")]
    public int hpLevel;
    public int atkLevel;
    public int criticalChancePercentLevel;
    public int criticalDamagePercentLevel;
    public int totalDamagePercentLevel;

    // 증가량 (각 업그레이드 당 증가하는 수치)
    [Header("증가량")]
    public float hpIncreaseAmount;
    public float atkIncreaseAmount;
    public float criticalChancePercentIncreaseAmount;
    public float criticalDamagePercentIncreaseAmount;
    public float totalDamagePercentIncreaseAmount;

    // 가격 (업그레이드 당 비용)
    [Header("가격")]
    public int hpUpgradeCost;
    public int atkUpgradeCost;
    public int criticalChancePercentUpgradeCost;
    public int criticalDamagePercentUpgradeCost;
    public int totalDamagePercentUpgradeCost;

    // 증가된 수치 (기본 값 + 업그레이드로 인해 증가된 값)
    [Header("증가된 수치")]
    public float currentHp;
    public float currentAtk;
    [Range(0, 1)] public float currentCriticalChancePercent;
    public float currentCriticalDamagePercent;
    public float currentTotalDamagePercent;

}
