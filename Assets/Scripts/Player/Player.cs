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

    public StatHandler statHandler; 
    public HealthSystem healthSystem;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);

        animator = GetComponentInChildren<Animator>();
        statHandler = GetComponent<StatHandler>();
        healthSystem = GetComponent<HealthSystem>();

        animationData = new PlayerAnimationData();
        animationData.Init();

    }

    private void Start()
    {
        monsterObjectPool = FindFirstObjectByType<MonsterObjectPool>();

        StartCoroutine(WaitMonsterObjectPool());

    }

    private void Update()
    {
        stateMachine.Update();
    }

    IEnumerator WaitMonsterObjectPool()
    {
        bool isMonster = false;

        while (!isMonster)
        {
            if (stateMachine.Player.monsterObjectPool.monsters.Count != 0)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
                isMonster = true;
            }
            yield return null;
        }
    }

}
