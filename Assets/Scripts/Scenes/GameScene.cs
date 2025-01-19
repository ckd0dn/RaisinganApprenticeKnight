using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
  
    void Start()
    {
        Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if(count == totalCount)
            {
                StartLoaded();
            }
        });
    }

    // ���ҽ� �ε尡 ��� ������ �����ϴ� �Լ�
    private void StartLoaded()
    {
        StartCoroutine(Managers.Stage.StartWave());
    }
}
