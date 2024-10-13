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

        // ġ��Ÿ ���� ����
        if (Random.value < playerStatHandler.currentCriticalChance)
        {
            // ġ��Ÿ �߻�
            totalDamage *= (2 + playerStatHandler.currentCriticalDamage);
            IsCritical = true;
            Debug.Log("ġ��Ÿ!");
        }
        else
        {
            // ġ��Ÿ �̹߻�
            IsCritical = false;
            Debug.Log("�Ϲ� ����");
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
