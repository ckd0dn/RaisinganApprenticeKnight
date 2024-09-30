using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;

    public Animator animator;

    public PlayerAnimationData animationData;

    public MonsterObjectPool monsterObjectPool;
    public Monster closestMonster;  // 가장 가까운 몬스터 저장

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

        // 충돌한 오브젝트의 레이어가 "Monster"인지 확인
        if (collision.gameObject.layer == monsterLayer)
        {
            stateMachine.ChangeState(stateMachine.AttackState);

            // 충돌한 오브젝트 비활성화
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.Die();
            //collision.gameObject.SetActive(false);  
        }
    }


}
