using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StagePanel : MonoBehaviour
{
    public TextMeshProUGUI stageText;

    private void Awake()
    {
        stageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateStageText(int startWave, int endWave)
    {
        stageText.text = $"{startWave} - {endWave}";
    }
}
