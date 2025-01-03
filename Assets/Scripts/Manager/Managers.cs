using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    GameManager gameManager = new GameManager();
    StageManager stageManager = new StageManager();

    public static GameManager Game { get { return Instance.gameManager; } }
    public static StageManager Stage { get { return Instance.stageManager; } }



    private void Start()
    {
        StartCoroutine(Stage.StartWave());
    }

}
