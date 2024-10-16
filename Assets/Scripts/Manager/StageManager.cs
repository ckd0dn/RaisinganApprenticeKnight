using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("���̺�")]
    private int startWave = 1;                              // ���� ���̺�
    private int endWave = 0;                                // ������ ���̺�
    [SerializeField] private int maxWave = 5;               // �ִ� ���̺�
    [Header("����")]
    private MonsterObjPool monsterObjPool;
    public int currentMonsterCount = 0;                          // ���� ���� ��
    [SerializeField] private int monsterWaveCount = 20;          // ���̺� ���� ��
    [SerializeField] private int monstersPerWaveIncrease = 5;    // ���̺꺰 ���� ������
    int monsterNum = 1;                                          // ���� ��ȣ
    [Header("UI")]
    StagePanel stagePanel;

    protected override void Awake()
    {
        base.Awake();
        monsterObjPool = FindFirstObjectByType<MonsterObjPool>();
        stagePanel = FindFirstObjectByType<StagePanel>();
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        while (true)
        {

            if(currentMonsterCount == 0)
            {

                CheckWaveEvent(); // Ư�� ���̺� �̺�Ʈ ó��

                // ������Ʈ UI
                stagePanel.UpdateStageText(startWave, endWave);

                yield return new WaitForSeconds(2f);
     
                SpawnMonsters(monsterNum.ToString());
             
            }

            yield return null;
        }
    }

    void CheckWaveEvent()
    {

        if (endWave == 5)
        {
            startWave++;
            endWave = 1;
            currentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
            monsterNum++;
        }
        else
        {
            endWave++;
            currentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
        }

    }

    void SpawnMonsters(string monsterNum)
    {
        for (int i = 0; i < currentMonsterCount; i++)
        {
            Monster monster = monsterObjPool.SpawnFromPool(monsterNum);
            monster.Set();
        }
    }

}
