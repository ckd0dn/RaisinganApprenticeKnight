using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public PlayerDieState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        StartAnimation(stateMachine.Player.animationData.MoveParameterHash);
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        StopAnimation(stateMachine.Player.animationData.MoveParameterHash);
    }


}
