using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerStateMachine stateMachine;

    public Animator animator;

    public PlayerAnimationData animationData;

    public Monster closestMonster;  // 가장 가까운 몬스터 저장

    public StatHandler statHandler; 
    public HealthSystem healthSystem;
    private PlayerHpBar hpBar;

    [SerializeField] private float resetCoolTime = 5f; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new PlayerStateMachine(this);
        hpBar = GetComponentInChildren<PlayerHpBar>();

        animator = GetComponentInChildren<Animator>();
        statHandler = GetComponent<StatHandler>();
        healthSystem = GetComponent<HealthSystem>();

        animationData = new PlayerAnimationData();
        animationData.Init();

    }

    private void Start()
    {
        healthSystem.OnDeath += Die;

        stateMachine.ChangeState(stateMachine.MoveState);

    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void Die()
    {
        stateMachine.ChangeState(stateMachine.DieState);

        StartCoroutine(Managers.Stage.ResetWave());
    }

    public void Reset()
    {
        StartCoroutine(ResetRoutine());
    }

    private IEnumerator ResetRoutine()
    {
        yield return new WaitForSeconds(resetCoolTime);

        // 스탯 초기화
        statHandler.InitializeStats();
        hpBar.UpdateHpBar();
        // 이동 상태로 변경
        stateMachine.ChangeState(stateMachine.MoveState);

    }

}
