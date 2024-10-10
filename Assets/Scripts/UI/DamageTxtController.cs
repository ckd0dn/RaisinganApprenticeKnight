using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTxtController : MonoBehaviour
{
    DamageTxtObjectPool damageTxtObjectPool;

    [SerializeField] private int damageTxtCount;

    private void Awake()
    {
        damageTxtObjectPool = GetComponent<DamageTxtObjectPool>();
    }

    void Init()
    {
        for (int i = 0; i < damageTxtCount; i++)
        {
            DamageTxt damageTxt = damageTxtObjectPool.objectPool.Get();
        }
    }
}
