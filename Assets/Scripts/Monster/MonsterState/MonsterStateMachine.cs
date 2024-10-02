using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; }

    public MonsterMoveState MoveState { get; private set; } 
    public MonsterAttackState AttackState { get; private set; } 
    public MonsterDieState DieState { get; private set; } 

    public MonsterStateMachine(Monster montser)
    {
        this.Monster = montser;

        MoveState = new MonsterMoveState(this);
        AttackState = new MonsterAttackState(this);
        DieState = new MonsterDieState(this);

    }
}
