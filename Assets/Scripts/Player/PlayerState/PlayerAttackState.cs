using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    float timer;
    float delayTime = 1f; 

    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        StartAnimation(stateMachine.Player.animationData.AttackParameterHash);
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if(timer > delayTime) 
        {
            // ���ݳ� Move ���·� ���ư�
            timer = 0f;
            stateMachine.ChangeState(stateMachine.MoveState);
        }
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.Player.animationData.AttackParameterHash);
    }


}
