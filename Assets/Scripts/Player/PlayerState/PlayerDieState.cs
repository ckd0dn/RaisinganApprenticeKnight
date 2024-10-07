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
        StartBoolAnimation(stateMachine.Player.animationData.DieParameterHash);

        stateMachine.Player.Reset();
    }

    public override void Update()
    {

    }

    public override void Exit()
    {

    }


}
