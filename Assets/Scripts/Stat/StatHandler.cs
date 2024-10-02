using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public StatSO baseStats; // 기본 스탯을 참조

    // 현재 스탯 (기본 스탯 + 강화 스탯)
    public float currentHp;
    public float maxHp;
    public float currentAtk;
    public float currentCriticalChance;
    public float currentCriticalDamage;
    public float currentTotalDamage;

    void Awake()
    {
        InitializeStats();
    }

    public void InitializeStats()
    {
        currentHp = baseStats.hp;
        maxHp = baseStats.hp;
        currentAtk = baseStats.atk;
        currentCriticalChance = baseStats.criticalChancePercent;
        currentCriticalDamage = baseStats.criticalDamagePercent;
        currentTotalDamage = baseStats.totalDamagePercent;
    }
}