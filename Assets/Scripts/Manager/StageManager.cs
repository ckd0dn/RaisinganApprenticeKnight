using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager
{
    private int startWave = 1;                              // 시작 웨이브
    private int endWave = 0;                                // 마지막 웨이브
    private int maxWave = 5;               // 최대 웨이브
    public bool isBossWave = false;
    public MonsterObjPool MonsterObjPool { get; set; }
    public int CurrentMonsterCount { get; set; } = 0;                          // 현재 몬스터 수
    private int monsterWaveCount = 5;          // 웨이브 몬스터 수
    private int monstersPerWaveIncrease = 5;    // 웨이브별 몬스터 증가량
    int monsterNum = 1;                                          // 몬스터 번호
    int bossMonsterNum = 101;                                    // 보스몬스터 번호
    public StagePanel StagePanel { get; set; }
    public BossUI BossUI { get; set; }

    public IEnumerator StartWave()
    {
        while (true)
        {
            if(CurrentMonsterCount == 0)
            {

                CheckWaveEvent(); // 특정 웨이브 이벤트 처리

                if (!isBossWave)
                {
                    // 업데이트 UI
                    StagePanel.UpdateStageText(startWave, endWave);

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
                CurrentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
                monsterNum++;
            }
   
        }
        else
        {
            endWave++;
            CurrentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;
        }

    }

    void StartBossWave()
    {
        CurrentMonsterCount = 1;
        SpawnMonsters(bossMonsterNum.ToString());
    }


    void SpawnMonsters(string monsterNum)
    {
        for (int i = 0; i < CurrentMonsterCount; i++)
        {
            Monster monster = MonsterObjPool.SpawnFromPool(monsterNum);
            monster.Set();
        }
    }

    public IEnumerator ResetWave()
    {
        BossMonster activeBossMonsters =  Managers.Game.MonsterObjPool.monsterList.OfType<BossMonster>().FirstOrDefault(monster => monster.gameObject.activeSelf);

        if (activeBossMonsters != null)
        {
            activeBossMonsters.gameObject.SetActive(false);
            BossUI.DisableBossUI();
            isBossWave = false;
        }

        endWave = 1;
        CurrentMonsterCount = monsterWaveCount + endWave * monstersPerWaveIncrease;

        StagePanel.UpdateStageText(startWave, endWave);

        yield return new WaitForSeconds(2f);

        SpawnMonsters(monsterNum.ToString());
    }

}
