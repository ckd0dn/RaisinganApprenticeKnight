using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    private Slider slider;
    private Monster monster;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        monster = GetComponentInParent<Monster>();
    }

    private void Start()
    {
        monster.healthSystem.OnHealthChanged += UpdateHpBar;
    }

    public void UpdateHpBar()
    {
        slider.value = monster.statHandler.currentHp / monster.statHandler.maxHp; 
    }
}
