using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Monster montser;
    private Player player;

    private void Awake()
    {
        montser = GetComponent<Monster>();
        player = FindFirstObjectByType<Player>();
    }

    public void BaseAttack()
    {
        player.healthSystem.ChangeHealth(-montser.statHandler.currentAtk);
    }
}
