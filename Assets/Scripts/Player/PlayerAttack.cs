using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player player;
    private StatHandler playerStatHandler;
    public bool IsCritical = false;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        playerStatHandler = player.statHandler;
    }

    public float CalculateDamage()
    {
        float totalDamage = playerStatHandler.currentAtk;

        // 치명타 여부 결정
        if (Random.value < playerStatHandler.currentCriticalChance)
        {
            // 치명타 발생
            totalDamage *= (2 + playerStatHandler.currentCriticalDamage);
            IsCritical = true;
            Debug.Log("치명타!");
        }
        else
        {
            // 치명타 미발생
            IsCritical = false;
            Debug.Log("일반 공격");
        }

        totalDamage *= (1 + playerStatHandler.currentTotalDamage);

        return totalDamage;
    }

    public void BaseAttack()
    {
        int totalDamage = (int)CalculateDamage();

        player.closestMonster.healthSystem.ChangeHealth(-totalDamage, IsCritical);
    }
}
