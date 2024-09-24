using UnityEngine;
using UnityEngine.Pool;

public class GameManager : Singleton<GameManager>
{
    private MonsterObjectPool monsterObjectPool;
    [SerializeField] private int monsterCount;

    protected override void Awake()
    {
        monsterObjectPool = FindFirstObjectByType<MonsterObjectPool>();
    }

    private void Start()
    {
        SpawnMonsters();
    }

    void SpawnMonsters()
    {
        for (int i = 0; i < monsterCount; i++ )
        {
            Monster monster = monsterObjectPool.objectPool.Get();
            monster.SetRandomPosition(monster);
        }
    }

}
