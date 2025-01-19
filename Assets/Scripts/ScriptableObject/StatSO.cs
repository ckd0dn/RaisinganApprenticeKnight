using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class StatSO : ScriptableObject
{
    public float hp;
    public float atk;
    [Range(0, 1)] public float criticalChancePercent;
    public float criticalDamagePercent;
    public float totalDamagePercent;
    [Header("Monser")]
    public int dropGold;

}
