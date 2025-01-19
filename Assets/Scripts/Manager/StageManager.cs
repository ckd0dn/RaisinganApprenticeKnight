using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager
{
    private int startWave = 1;                              // ���� ���̺�
    private int endWave = 0;                                // ������ ���̺�
    private int maxWave = 5;               // �ִ� ���̺�
    public bool isBossWave = false;
    public MonsterObjPool MonsterObjPool { get; set; }
    public int CurrentMonsterCount { get; set; } = 0;                          // ���� ���� ��
    private int monsterWaveCount = 5;          // ���̺� ���� ��
    private int monstersPerWaveIncrease = 5;    // ���̺꺰 ���� ������
    int monsterNum = 1;                                          // ���� ��ȣ
    int bossMonsterNum = 101;                                    // �������� ��ȣ
    public StagePanel StagePanel { get; set; }
    public BossUI BossUI { get; set; }

    public IEnumerator StartWave()
    {
        while (true)
        {
            if(CurrentMonsterCount == 0)
            {

                CheckWaveEvent(); // Ư�� ���̺� �̺�Ʈ ó��

                if (!isBossWave)
                {
                    // ������Ʈ UI
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
                // ���� ���̺�
                StartBossWave();
            }
            else 
            {
                // ���� ���̺�
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
