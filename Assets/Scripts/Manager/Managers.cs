using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    GameManager gameManager = new GameManager();
    StageManager stageManager = new StageManager();
    ResourceManager resourceManager = new ResourceManager();

    public static GameManager Game { get { return Instance.gameManager; } }
    public static StageManager Stage { get { return Instance.stageManager; } }
    public static ResourceManager Resource { get { return Instance.resourceManager; } }


    private void Start()
    {
        StartCoroutine(Stage.StartWave());
    }

}
