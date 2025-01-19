using UnityEngine;
using System.Linq;
using System.Collections;

public class MonsterMoveState : MonsterBaseState
{
    public float speed = .5f;      // 이동 속도
    public float distance = 1f;

    public MonsterMoveState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        StartBoolAnimation(stateMachine.Monster.animationData.MoveParameterHash);
    }

    public override void Update()
    {
        MoveToPlayer();
    }

    public override void Exit()
    {

        StopAnimation(stateMachine.Monster.animationData.MoveParameterHash);
    }

    void MoveToPlayer()
    {
        Vector3 MonsterPosition = stateMachine.Monster.transform.position;
        Vector3 PlayerPosition = stateMachine.Monster.player.transform.position;

        stateMachine.Monster.transform.position = Vector2.MoveTowards(MonsterPosition, PlayerPosition, speed * Time.deltaTime);

        if (Vector2.Distance(MonsterPosition, PlayerPosition) <= distance)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }


}
