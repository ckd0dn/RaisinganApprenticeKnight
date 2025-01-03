using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{
    private MonsterStateMachine stateMachine;
    private BossUI bossUI;
    public Sprite bossSprite; 

    protected override void Awake()
    {
        base.Awake();

        bossUI =  FindFirstObjectByType<BossUI>();
        GetBodySprite();

        stateMachine = new MonsterStateMachine(this);
        stateMachine.MoveState.distance = 3;
    }

    private void Start()
    {
        healthSystem.OnDeath += Die;
        stateMachine.ChangeState(stateMachine.MoveState);
        healthSystem.OnHealthChangedWithParams += bossUI.UpdateBossHp;
    }

    private void Update()
    {
        stateMachine.Update();
    }


    public override void Set()
    {
        SetPosition();
        // 방향 초기화
        transform.rotation = Quaternion.identity;
        // 스탯 초기화
        statHandler.InitializeStats();
        // 보스 UI 활성화
        bossUI.SetBossData((int)statHandler.currentHp, bossSprite);
        bossUI.AppearBossUI();
        // 초기화되면 이동
        stateMachine.ChangeState(stateMachine.MoveState);
    }

    public override void Die()
    {
        stateMachine.ChangeState(stateMachine.DieState);
        Managers.Stage.CurrentMonsterCount--;
        DropGold();
        // 보스 UI 비활성화
        bossUI.DisableBossUI();
    }

    private void DropGold()
    {
        // TODO 골드 이미지가 뿌려지고 먹어지는 로직

        // 실제로 골드 재화를 얻음
        Managers.Game.currency.AddGold(statHandler.dropGold);
    }

    void SetPosition()
    {
        int x = 0;
        int y = -50;
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void GetBodySprite()
    {
        Transform bodyTransform = transform.Find("Body");
        if (bodyTransform != null)
        {
            SpriteRenderer spriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                bossSprite = spriteRenderer.sprite;
            }
        }
    }
}
