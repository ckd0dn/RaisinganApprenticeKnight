using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : BaseController
{
    public Player player;

    [SerializeField] private float speed;

    public HealthSystem healthSystem;
    public StatHandler statHandler;
    public Animator animator;
    public MonsterAnimationData animationData;
    private MonsterStateMachine stateMachine;
    private MonsterHpBar monsterHpBar;

    public bool isDie = false;

    public override void Init()
    {
        ObjectType = Define.ObjectType.Monster;

        player = FindFirstObjectByType<Player>();
        healthSystem = GetComponent<HealthSystem>();
        statHandler = GetComponent<StatHandler>();
        animator = GetComponent<Animator>();
        monsterHpBar = GetComponentInChildren<MonsterHpBar>();
        animationData = new MonsterAnimationData();
        animationData.Init();
        stateMachine = new MonsterStateMachine(this);
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


    public virtual void Set()
    {
        // 위치 랜덤으로 정함
        SetRandomPosition(this);
        // 방향 초기화
        transform.rotation = Quaternion.identity;
        // 스탯 초기화
        statHandler.InitializeStats();
        monsterHpBar.UpdateHpBar();
        isDie = false;
        monsterHpBar.gameObject.SetActive(true);

        // 초기화되면 이동
        stateMachine.ChangeState(stateMachine.MoveState); 
    }

    public virtual void Die()
    {
        stateMachine.ChangeState(stateMachine.DieState);
        Managers.Stage.CurrentMonsterCount--;
        DropGold();
        monsterHpBar.gameObject.SetActive(false);
    }

    protected virtual void SetRandomPosition(Monster monster)
    {
        int minX = -9;
        int maxX = 8;
        int minY = -59;
        int maxY = -44;
        int randomOffsetX = Random.Range(minX, maxX);
        int randomOffsetY = Random.Range(minY, maxY);

        monster.transform.position = new Vector3(randomOffsetX, randomOffsetY, transform.position.z);
    }

    private void DropGold()
    {
        // TODO 골드 이미지가 뿌려지고 먹어지는 로직

        // 실제로 골드 재화를 얻음
        Managers.Game.currency.AddGold(statHandler.dropGold);
    }

}