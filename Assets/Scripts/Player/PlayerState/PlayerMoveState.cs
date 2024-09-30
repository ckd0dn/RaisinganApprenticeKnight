using UnityEngine;
using System.Linq;

public class PlayerMoveState : PlayerBaseState
{
    public float speed = 5f;      // 이동 속도

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        StartAnimation(stateMachine.Player.animationData.MoveParameterHash);
    }

    public override void Update()
    {
        FindClosestMonster();

        if (stateMachine.Player.closestMonster != null)
        {
            MoveToMonster();
        }
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.Player.animationData.MoveParameterHash);
    }

    void MoveToMonster()
    {
        stateMachine.Player.transform.position = Vector2.MoveTowards(stateMachine.Player.transform.position, stateMachine.Player.closestMonster.transform.position, speed * Time.deltaTime);
    }

    void FindClosestMonster()
    {
        if (stateMachine.Player.monsterObjectPool.monsters != null)
        {
            // 모든 몬스터와의 거리를 계산하여 가장 가까운 몬스터 찾기
            stateMachine.Player.closestMonster = stateMachine.Player.monsterObjectPool.monsters
                .Where(monster => monster.gameObject.activeInHierarchy)
                .OrderBy(monster => Vector3.Distance(stateMachine.Player.transform.position, monster.transform.position))
                .FirstOrDefault();
        }

    }


}
