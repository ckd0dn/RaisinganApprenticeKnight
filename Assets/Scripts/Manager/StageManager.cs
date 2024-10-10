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
    private MonsterObjectPool monsterObjectPool;
    public int currentMonsterCount = 0;                             // ���� ���� ��
    [SerializeField] private int monsterWaveCount = 20;          // ���̺� ���� ��
    [SerializeField] private int monstersPerWaveIncrease = 5;   // ���̺꺰 ���� ������
    [Header("UI")]
    StagePanel stagePanel;

    protected override void Awake()
    {
        base.Awake();
        monsterObjectPool = FindFirstObjectByType<MonsterObjectPool>();
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
            Debug.Log(currentMonsterCount);

            if(currentMonsterCount == 0)
            {

                CheckWaveEvent(); // Ư�� ���̺� �̺�Ʈ ó��

                // ������Ʈ UI
                stagePanel.UpdateStageText(startWave, endWave);

                yield return new WaitForSeconds(2f);
     
                SpawnMonsters();
             
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
        }
        else
        {
            endWave++;
            currentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
        }

    }

    void SpawnMonsters()
    {
        for (int i = 0; i < currentMonsterCount; i++)
        {
            Monster monster = monsterObjectPool.objectPool.Get();
            monster.Set();
        }
    }

}
