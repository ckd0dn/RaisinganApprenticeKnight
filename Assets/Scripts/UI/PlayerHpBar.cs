using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    private Slider slider;
    private Player player;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        player = FindFirstObjectByType<Player>();
    }

    private void Start()
    {
        player.healthSystem.OnHealthChanged += UpdateHpBar;
    }

    public void UpdateHpBar()
    {
        slider.value = player.statHandler.currentHp / player.statHandler.maxHp; 
    }
}
