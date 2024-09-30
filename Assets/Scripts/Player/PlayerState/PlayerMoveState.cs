using UnityEngine;
using System.Linq;

public class PlayerMoveState : PlayerBaseState
{
    public float speed = 5f;      // �̵� �ӵ�

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
            // ��� ���Ϳ��� �Ÿ��� ����Ͽ� ���� ����� ���� ã��
            stateMachine.Player.closestMonster = stateMachine.Player.monsterObjectPool.monsters
                .Where(monster => monster.gameObject.activeInHierarchy)
                .OrderBy(monster => Vector3.Distance(stateMachine.Player.transform.position, monster.transform.position))
                .FirstOrDefault();
        }

    }


}
