using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;

    public Animator animator;

    public PlayerAnimationData animationData;

    public MonsterObjectPool monsterObjectPool;
    public Monster closestMonster;  // ���� ����� ���� ����

    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);

        animator = GetComponentInChildren<Animator>();  

        animationData = new PlayerAnimationData();
        animationData.Init();

        monsterObjectPool = FindFirstObjectByType<MonsterObjectPool>();

    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.MoveState);   
    }

    private void Update()
    {
        stateMachine.Update();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        int monsterLayer = LayerMask.NameToLayer("Monster");

        // �浹�� ������Ʈ�� ���̾ "Monster"���� Ȯ��
        if (collision.gameObject.layer == monsterLayer)
        {
            stateMachine.ChangeState(stateMachine.AttackState);

            // �浹�� ������Ʈ ��Ȱ��ȭ
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.Die();
            //collision.gameObject.SetActive(false);  
        }
    }


}
