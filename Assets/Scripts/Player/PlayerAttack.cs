using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();    
    }

    public void BaseAttack()
    {
        player.closestMonster.healthSystem.ChangeHealth(-player.statHandler.currentAtk);
    }
}
