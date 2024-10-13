using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : MonoBehaviour
{
    public IObjectPool<Monster> objectPool;

    public IObjectPool<Monster> ObjectPool { set => objectPool = value; }

    public Player player;

    [SerializeField] private float speed;

    public HealthSystem healthSystem;
    public StatHandler statHandler;
    public Animator animator;
    public MonsterAnimationData animationData;
    private MonsterStateMachine stateMachine;
    private MonsterHpBar monsterHpBar;

    public bool isDie = false;

    private void Awake()
    {
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


    public void Set()
    {
        // 위치 랜덤으로 정함
        SetRandomPosition(this);
        // 방향 초기화
        transform.eulerAngles = Vector3.zero;
        // 스탯 초기화
        statHandler.InitializeStats();
        monsterHpBar.UpdateHpBar();
        isDie = false;
        monsterHpBar.gameObject.SetActive(true);

        // 초기화되면 이동
        stateMachine.ChangeState(stateMachine.MoveState); 
    }

    public void Die()
    {
        stateMachine.ChangeState(stateMachine.DieState);
        StageManager.Instance.currentMonsterCount--;
        DropGold();
        monsterHpBar.gameObject.SetActive(false);
    }

    public void SetRandomPosition(Monster monster)
    {
        int minX = -9;
        int maxX = 8;
        int minY = -9;
        int maxY = -4;
        int randomOffsetX = Random.Range(minX, maxX);
        int randomOffsetY = Random.Range(minY, maxY);

        monster.transform.position = new Vector3(randomOffsetX, randomOffsetY, transform.position.z);
    }

    private void DropGold()
    {
        // TODO 골드 이미지가 뿌려지고 먹어지는 로직

        // 실제로 골드 재화를 얻음
        GameManager.Instance.currency.AddGold(statHandler.dropGold);
    }

}