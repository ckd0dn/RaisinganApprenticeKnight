using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    float timer;
    float delayTime = .3f; 

    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {

        StartAnimation(stateMachine.Player.animationData.AttackParameterHash);

        stateMachine.Player.closestMonster.healthSystem.OnDeath += ChangeMoveState;
    }

    public override void Update()
    {
        // Attack();
    }

    public override void Exit()
    {

        StopAnimation(stateMachine.Player.animationData.AttackParameterHash);

        stateMachine.Player.closestMonster.healthSystem.OnDeath -= ChangeMoveState; 
    }

    public void Attack()
    {
        timer += Time.deltaTime;

        if (timer > delayTime)
        {
            stateMachine.Player.closestMonster.healthSystem.ChangeHealth(stateMachine.Player.statHandler.currentAtk);
            timer = 0f;
        }
    }

    private void ChangeMoveState()
    {
        stateMachine.ChangeState(stateMachine.MoveState);
    }


}
