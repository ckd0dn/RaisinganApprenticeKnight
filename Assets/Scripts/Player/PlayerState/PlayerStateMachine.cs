using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    public PlayerMoveState MoveState { get; private set; } 
    public PlayerAttackState AttackState { get; private set; } 
    public PlayerDieState DieState { get; private set; } 

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        MoveState = new PlayerMoveState(this);
        AttackState = new PlayerAttackState(this);
        DieState = new PlayerDieState(this);

    }
}
