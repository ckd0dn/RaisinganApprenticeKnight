using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("웨이브")]
    private int startWave = 1;                              // 시작 웨이브
    private int endWave = 0;                                // 마지막 웨이브
    [SerializeField] private int maxWave = 5;               // 최대 웨이브
    public bool isBossWave = false;
    [Header("몬스터")]
    private MonsterObjPool monsterObjPool;
    public int currentMonsterCount = 0;                          // 현재 몬스터 수
    [SerializeField] private int monsterWaveCount = 20;          // 웨이브 몬스터 수
    [SerializeField] private int monstersPerWaveIncrease = 5;    // 웨이브별 몬스터 증가량
    int monsterNum = 1;                                          // 몬스터 번호
    int bossMonsterNum = 101;                                    // 보스몬스터 번호
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

                CheckWaveEvent(); // 특정 웨이브 이벤트 처리

                if (!isBossWave)
                {
                    // 업데이트 UI
                    stagePanel.UpdateStageText(startWave, endWave);

                    yield return new WaitForSeconds(2f);

                    SpawnMonsters(monsterNum.ToString());
                }
 
            }

            yield return null;
        }
    }

    void CheckWaveEvent()
    {

        if (endWave == 5)
        {
            isBossWave = !isBossWave; 

            if (isBossWave)
            {
                // 보스 웨이브
                StartBossWave();
            }
            else 
            {
                // 다음 웨이브
                bossMonsterNum++;
                startWave++;
                endWave = 1;
                currentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
                monsterNum++;
            }
   
        }
        else
        {
            endWave++;
            currentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
        }

    }

    void StartBossWave()
    {
        currentMonsterCount = 1;
        SpawnMonsters(bossMonsterNum.ToString());
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
