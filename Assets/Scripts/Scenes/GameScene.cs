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

    // 리소스 로드가 모두 끝나고 시작하는 함수
    private void StartLoaded()
    {
        StartCoroutine(Managers.Stage.StartWave());
    }
}
