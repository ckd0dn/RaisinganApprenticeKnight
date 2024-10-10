using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : Singleton<GameManager>
{
    private MonsterObjectPool monsterObjectPool;
    public DamageTxtObjectPool damageTxtObjectPool;
    [SerializeField] private int monsterCount;
    public Currency currency;

    protected override void Awake()
    {
        monsterObjectPool = FindFirstObjectByType<MonsterObjectPool>();
        damageTxtObjectPool = FindFirstObjectByType<DamageTxtObjectPool>();
        currency = GetComponent<Currency>();
    }


    void SpawnMonsters()
    {
        for (int i = 0; i < monsterCount; i++ )
        {
            Monster monster = monsterObjectPool.objectPool.Get();
            monster.Set();
        }
    }

    public void ReSpawnMonsters()
    {

        if(monsterObjectPool.objectPool.CountInactive == monsterCount)
        {
            SpawnMonsters();
        }
    }

}
