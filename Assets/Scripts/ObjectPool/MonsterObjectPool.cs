using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterObjectPool : MonoBehaviour
{
    [Tooltip("Prefab")]
    [SerializeField] private Monster monsterPrefab;

    // stack-based ObjectPool available with Unity 2021 and above
    public IObjectPool<Monster> objectPool;

    // throw an exception if we try to return an existing item, already in the pool
    [SerializeField] private bool collectionCheck = true;

    // extra options to control the pool capacity and maximum size
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    public List<Monster> monsters;

    private void Awake()
    {
        Debug.Log("몬스터 오브젝트플 생성");


        objectPool = new ObjectPool<Monster>(CreateMonster,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);

    }

    // invoked when creating an item to populate the object pool
    private Monster CreateMonster()
    {
        Debug.Log("몬스터 생성");

        Monster monsterInstance = Instantiate(monsterPrefab, transform);
        monsterInstance.ObjectPool = objectPool;

        monsters.Add(monsterInstance);

        return monsterInstance;
    }

    // invoked when returning an item to the object pool
    private void OnReleaseToPool(Monster pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    // invoked when retrieving the next item from the object pool
    private void OnGetFromPool(Monster pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(Monster pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

  

}
