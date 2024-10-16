using UnityEngine;
using System.Linq;
using System.Collections;

public class PlayerMoveState : PlayerBaseState
{
    public float speed = 2f;      // 이동 속도
    private float distance = 1f;

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
        Vector3 playerPosition = stateMachine.Player.transform.position;
        Vector3 closestMonsterPosition = stateMachine.Player.closestMonster.transform.position;

        stateMachine.Player.transform.position = Vector2.MoveTowards(playerPosition, closestMonsterPosition, speed * Time.deltaTime);

        if (Vector2.Distance(playerPosition, closestMonsterPosition) <= distance)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }

        // 몬스터와의 방향을 계산
        //Vector3 direction = (closestMonsterPosition - playerPosition).normalized;

        // 플레이어가 몬스터 쪽으로 바라보도록 회전

        // RigidBody를 사용하여 몬스터 방향으로 이동
        //stateMachine.Player.rb.velocity = direction * speed;

        //if (Vector2.Distance(playerPosition, closestMonsterPosition) <= distance)
        //{
        //    stateMachine.ChangeState(stateMachine.AttackState);
        //}


    }

    void FindClosestMonster()
    {

        if (GameManager.Instance.monsterObjPool.monsterList.Count != 0)
        {
            // 모든 몬스터와의 거리를 계산하여 가장 가까운 몬스터 찾기
            stateMachine.Player.closestMonster = GameManager.Instance.monsterObjPool.monsterList
                .Where(monster => monster.gameObject.activeSelf)
                .Where(monster => !monster.isDie)
                .OrderBy(monster => Vector3.Distance(stateMachine.Player.transform.position, monster.transform.position))
                .FirstOrDefault();


        }

    }



}
