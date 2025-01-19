using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{

    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        StartBoolAnimation(stateMachine.Monster.animationData.AttackParameterHash);
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.Monster.animationData.AttackParameterHash);
    }

}
