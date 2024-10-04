using UnityEngine;
using System.Linq;
using System.Collections;

public class PlayerMoveState : PlayerBaseState
{
    public float speed = 2f;      // �̵� �ӵ�
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
    }

    void FindClosestMonster()
    {

        if (stateMachine.Player.monsterObjectPool.monsters.Count != 0)
        {
            // ��� ���Ϳ��� �Ÿ��� ����Ͽ� ���� ����� ���� ã��
            stateMachine.Player.closestMonster = stateMachine.Player.monsterObjectPool.monsters
                .Where(monster => monster.gameObject.activeSelf)
                .Where(monster => !monster.isDie)
                .OrderBy(monster => Vector3.Distance(stateMachine.Player.transform.position, monster.transform.position))
                .FirstOrDefault();


        }

    }



}
