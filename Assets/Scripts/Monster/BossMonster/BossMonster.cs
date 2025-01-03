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
        // ���� �ʱ�ȭ
        transform.rotation = Quaternion.identity;
        // ���� �ʱ�ȭ
        statHandler.InitializeStats();
        // ���� UI Ȱ��ȭ
        bossUI.SetBossData((int)statHandler.currentHp, bossSprite);
        bossUI.AppearBossUI();
        // �ʱ�ȭ�Ǹ� �̵�
        stateMachine.ChangeState(stateMachine.MoveState);
    }

    public override void Die()
    {
        stateMachine.ChangeState(stateMachine.DieState);
        Managers.Stage.CurrentMonsterCount--;
        DropGold();
        // ���� UI ��Ȱ��ȭ
        bossUI.DisableBossUI();
    }

    private void DropGold()
    {
        // TODO ��� �̹����� �ѷ����� �Ծ����� ����

        // ������ ��� ��ȭ�� ����
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
