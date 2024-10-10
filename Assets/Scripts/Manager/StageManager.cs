using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("웨이브")]
    private int startWave = 1;                              // 시작 웨이브
    private int endWave = 0;                                // 마지막 웨이브
    [SerializeField] private int maxWave = 5;               // 최대 웨이브
    [Header("몬스터")]
    private MonsterObjectPool monsterObjectPool;
    public int currentMonsterCount = 0;                             // 현재 몬스터 수
    [SerializeField] private int monsterWaveCount = 20;          // 웨이브 몬스터 수
    [SerializeField] private int monstersPerWaveIncrease = 5;   // 웨이브별 몬스터 증가량
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

                CheckWaveEvent(); // 특정 웨이브 이벤트 처리

                // 업데이트 UI
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
