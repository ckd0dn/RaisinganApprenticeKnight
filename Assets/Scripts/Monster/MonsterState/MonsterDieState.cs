using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterDieState : MonsterBaseState
{
    private float timer;
    private float delay = 1f;
    public MonsterDieState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.Monster.isDie = true;

        StartBoolAnimation(stateMachine.Monster.animationData.DieParameterHash);
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            stateMachine.Monster.gameObject.SetActive(false);
            timer = 0;
        }
    }

    public override void Exit()
    {

    }


}
