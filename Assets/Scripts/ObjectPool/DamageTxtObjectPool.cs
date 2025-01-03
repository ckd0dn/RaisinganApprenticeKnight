using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class DamageTxtObjectPool : MonoBehaviour
{
    [Tooltip("Prefab")]
    [SerializeField] private DamageTxt damageTextPrefab;

    // stack-based ObjectPool available with Unity 2021 and above
    public IObjectPool<DamageTxt> objectPool;

    // throw an exception if we try to return an existing item, already in the pool
    [SerializeField] private bool collectionCheck = true;

    // extra options to control the pool capacity and maximum size
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    public List<DamageTxt> damageTxts;
    private Canvas canvas;

    private void Awake()
    {
        Managers.Game.DamageTxtObjectPool = this;

        canvas = GetComponentInChildren<Canvas>();

        objectPool = new ObjectPool<DamageTxt>(Create,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);
    }

    // invoked when creating an item to populate the object pool
    private DamageTxt Create()
    {
        DamageTxt damageTxtInstance = Instantiate(damageTextPrefab, canvas.transform);
        damageTxtInstance.ObjectPool = objectPool;

        damageTxts.Add(damageTxtInstance);

        return damageTxtInstance;
    }

    // invoked when returning an item to the object pool
    private void OnReleaseToPool(DamageTxt pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    // invoked when retrieving the next item from the object pool
    private void OnGetFromPool(DamageTxt pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(DamageTxt pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

  

}
