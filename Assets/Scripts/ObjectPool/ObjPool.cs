using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ObjPool<T> : MonoBehaviour where T : MonoBehaviour
{
    // 오브젝트 풀 데이터를 정의할 데이터 모음 정의
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public T prefab;
        public int size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<T>> PoolDictionary;


    protected virtual void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<T>>();
        foreach (var pool in Pools)
        {
            Queue<T> objectPool = new Queue<T>();
            for (int i = 0; i < pool.size; i++)
            {
                T obj = Instantiate(pool.prefab, transform);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public T SpawnFromPool(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        T obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);
        obj.gameObject.SetActive(true);
        return obj;
    }

}