using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    // UI
    [Header("UI")]
    public TextMeshProUGUI hpLvText;
    public TextMeshProUGUI atkLvText;
    public TextMeshProUGUI criticalChanceLvText;
    public TextMeshProUGUI criticalDamageLvText;
    public TextMeshProUGUI totalDamageLvText;

    public TextMeshProUGUI hpValueText;
    public TextMeshProUGUI atkValueText;
    public TextMeshProUGUI criticalChanceValueText;
    public TextMeshProUGUI criticalDamageValueText;
    public TextMeshProUGUI totalDamageValueText;

    public TextMeshProUGUI hpPriceText;
    public TextMeshProUGUI atkPriceText;
    public TextMeshProUGUI criticalChancePriceText;
    public TextMeshProUGUI criticalDamagePriceText;
    public TextMeshProUGUI totalDamagePriceText;

    // 레벨 
    [Header("레벨")]
    public int hpLevel;
    public int atkLevel;
    public int criticalChanceLevel;
    public int criticalDamageLevel;
    public int totalDamageLevel;

    // 증가량 (각 업그레이드 당 증가하는 수치)
    [Header("증가량")]
    public float hpIncreaseAmount;
    public float atkIncreaseAmount;
    public float criticalChanceIncreaseAmount;
    public float criticalDamageIncreaseAmount;
    public float totalDamageIncreaseAmount;

    // 가격 (업그레이드 당 비용)
    [Header("가격")]
    public int hpUpgradeCost;
    public int atkUpgradeCost;
    public int criticalChanceUpgradeCost;
    public int criticalDamageUpgradeCost;
    public int totalDamageUpgradeCost;

    // 가격 증가량
    [Header("가격 증가량")]
    public int hpUpgradeCostIncreaseAmount;
    public int atkUpgradeCostIncreaseAmount;
    public int criticalChanceUpgradeCostIncreaseAmount;
    public int criticalDamageUpgradeCostIncreaseAmount;
    public int totalDamageUpgradeCostIncreaseAmount;

    // 증가된 수치 (기본 값 + 업그레이드로 인해 증가된 값)
    [Header("증가된 수치")]
    public float currentHp;
    public float currentAtk;
    [Range(0, 1)] public float currentCriticalChance;
    public float currentCriticalDamage;
    public float currentTotalDamage;

    private StatHandler playerStat;

    private void Awake()
    {
        Player player = FindFirstObjectByType<Player>();
        playerStat = player.GetComponent<StatHandler>();
    }

    private void Start()
    {
        InitUI();
    }

    void InitUI()
    {
         hpUpgradeCost = hpUpgradeCostIncreaseAmount * hpLevel;
         atkUpgradeCost = atkUpgradeCostIncreaseAmount * atkLevel;
         criticalChanceUpgradeCost = criticalChanceUpgradeCostIncreaseAmount * criticalChanceLevel;
         criticalDamageUpgradeCost = criticalDamageUpgradeCostIncreaseAmount * criticalDamageLevel;
         totalDamageUpgradeCost = totalDamageUpgradeCostIncreaseAmount * totalDamageLevel;

         hpLvText.text = $"Lv {hpLevel}";
         atkLvText.text = $"Lv {atkLevel}";
         criticalChanceLvText.text = $"Lv {criticalChanceLevel}";
         criticalDamageLvText.text = $"Lv {criticalDamageLevel}";
         totalDamageLvText.text = $"Lv {totalDamageLevel}"; 

         hpValueText.text = (hpIncreaseAmount * (hpLevel-1)).ToString();
         atkValueText.text = (atkIncreaseAmount * (atkLevel-1)).ToString();
         criticalChanceValueText.text = $"{criticalChanceIncreaseAmount * (criticalChanceLevel-1) * 100}%"; 
         criticalDamageValueText.text = $"{criticalDamageIncreaseAmount * (criticalDamageLevel-1) * 100}%";
         totalDamageValueText.text = $"{totalDamageIncreaseAmount * (totalDamageLevel-1) * 100}%"; 

         hpPriceText.text = hpUpgradeCost.ToString();
         atkPriceText.text = atkUpgradeCost.ToString();
         criticalChancePriceText.text = criticalChanceUpgradeCost.ToString();
         criticalDamagePriceText.text = criticalDamageUpgradeCost.ToString();
         totalDamagePriceText.text = totalDamageUpgradeCost.ToString();
}

    public void UpgradeHp()
    {
        // 구매 
        bool canBuy = GameManager.Instance.currency.UseGold(hpUpgradeCost);
        if (!canBuy) return;
        // 체력 증가
        currentHp = hpIncreaseAmount * hpLevel; // 현재 체력 + 증가량
        playerStat.maxHp = playerStat.baseStats.hp + currentHp;
        playerStat.currentHp = playerStat.baseStats.hp + currentHp;
        // 업그레이드 레벨 증가
        hpLevel++;
        hpUpgradeCost = hpUpgradeCostIncreaseAmount * hpLevel;
        UpdateHpUI();
    }

    public void UpgradeAtk()
    {
        // 구매 
        bool canBuy = GameManager.Instance.currency.UseGold(atkUpgradeCost);
        if (!canBuy) return;
        // 공격력 증가
        currentAtk = atkIncreaseAmount * atkLevel; 
        playerStat.currentAtk = playerStat.baseStats.atk + currentAtk;
        // 업그레이드 레벨 증가
        atkLevel++;
        atkUpgradeCost = atkUpgradeCostIncreaseAmount * atkLevel;
        UpdateAtkUI();
    }

    public void UpgradeCriticalChance()
    {
        // 구매 
        bool canBuy = GameManager.Instance.currency.UseGold(criticalChanceUpgradeCost);
        if (!canBuy) return;
        // 크리티컬 확률 증가
        currentCriticalChance = criticalChanceIncreaseAmount * criticalChanceLevel;
        playerStat.currentCriticalChance = playerStat.baseStats.criticalChancePercent + currentCriticalChance;
        // 업그레이드 레벨 증가
        criticalChanceLevel++;
        criticalChanceUpgradeCost = criticalChanceUpgradeCostIncreaseAmount * criticalChanceLevel;
        UpdateCriticalChanceUI();
    }

    public void UpgradeCriticalDamage()
    {
        // 구매 
        bool canBuy = GameManager.Instance.currency.UseGold(criticalDamageUpgradeCost);
        if (!canBuy) return;
        // 크리티컬 데미지 증가
        currentCriticalDamage = criticalDamageIncreaseAmount * criticalDamageLevel;
        playerStat.currentCriticalDamage = playerStat.baseStats.criticalDamagePercent + currentCriticalDamage;
        // 업그레이드 레벨 증가
        criticalDamageLevel++;
        criticalDamageUpgradeCost = criticalDamageUpgradeCostIncreaseAmount * criticalDamageLevel;
        UpdateCriticalDamageUI();
    }

    public void UpgradeTotalDamage()
    {
        // 구매 
        bool canBuy = GameManager.Instance.currency.UseGold(totalDamageUpgradeCost);
        if (!canBuy) return;
        // 최종 데미지 증가
        currentTotalDamage = totalDamageIncreaseAmount * totalDamageLevel;
        playerStat.currentTotalDamage = playerStat.baseStats.totalDamagePercent + currentTotalDamage;
        // 업그레이드 레벨 증가
        totalDamageLevel++;
        totalDamageUpgradeCost = totalDamageUpgradeCostIncreaseAmount * totalDamageLevel;
        UpdateTotalDamageUI();
    }

    private void UpdateHpUI()
    {
        hpLvText.text = $"Lv {hpLevel}";
        hpValueText.text = currentHp.ToString();
        hpPriceText.text = hpUpgradeCost.ToString();
    }

    private void UpdateAtkUI()
    {
        atkLvText.text = $"Lv {atkLevel}";
        atkValueText.text = currentAtk.ToString();
        atkPriceText.text = atkUpgradeCost.ToString();
    }

    private void UpdateCriticalChanceUI()
    {
        criticalChanceLvText.text = $"Lv {criticalChanceLevel}";
        criticalChanceValueText.text = $"{currentCriticalChance*100}%";
        criticalChancePriceText.text = criticalChanceUpgradeCost.ToString();
    }

    private void UpdateCriticalDamageUI()
    {
        criticalDamageLvText.text = $"Lv {criticalDamageLevel}";
        criticalDamageValueText.text = $"{currentCriticalDamage * 100}%";
        criticalDamagePriceText.text = criticalDamageUpgradeCost.ToString();
    }

    private void UpdateTotalDamageUI()
    {
        totalDamageLvText.text = $"Lv {totalDamageLevel}";
        totalDamageValueText.text = $"{currentTotalDamage * 100}%";  
        totalDamagePriceText.text = totalDamageUpgradeCost.ToString();
    }
}
