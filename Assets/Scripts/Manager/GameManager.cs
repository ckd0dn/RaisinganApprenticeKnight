using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : Singleton<GameManager>
{
    public DamageTxtObjectPool damageTxtObjectPool;
    [SerializeField] private int monsterCount;
    public Currency currency;
    public MonsterObjPool monsterObjPool;
    [SerializeField] private float playTimeSpeed = 1f;

    protected override void Awake()
    {
        damageTxtObjectPool = FindFirstObjectByType<DamageTxtObjectPool>();
        currency = GetComponent<Currency>();
        monsterObjPool = FindFirstObjectByType<MonsterObjPool>();
    }

    private void Update()
    {
        Time.timeScale = playTimeSpeed;
    }


}
