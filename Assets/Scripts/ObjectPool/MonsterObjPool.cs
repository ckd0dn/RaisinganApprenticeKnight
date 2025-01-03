using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObjPool : ObjPool<Monster>
{
    public List<Monster> monsterList;

    protected override void Awake()
    {
        Init();

        PoolDictionary = new Dictionary<string, Queue<Monster>>();
        foreach (var pool in Pools)
        {
            Queue<Monster> objectPool = new Queue<Monster>();
            for (int i = 0; i < pool.size; i++)
            {
                Monster obj = Instantiate(pool.prefab, transform);
                monsterList.Add(obj);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    void Init()
    {
        Managers.Game.MonsterObjPool = this;
        Managers.Stage.MonsterObjPool = this;
    }
}
