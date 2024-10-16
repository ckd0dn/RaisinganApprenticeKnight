using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    private Slider slider;
    private Monster monster;
    private Collider monsterCollider;
    [SerializeField] float offsetY = -0.3f;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        monster = GetComponentInParent<Monster>();
        monsterCollider = monster.GetComponent<Collider>();
    }

    private void Start()
    {
        monster.healthSystem.OnHealthChanged += UpdateHpBar;
    }

    public void UpdateHpBar()
    {
        slider.value = monster.statHandler.currentHp / monster.statHandler.maxHp; 
    }

    void SetPosition()
    {
        float monsterHeight = monsterCollider.bounds.size.y;
        float monsterWidth = monsterCollider.bounds.size.x;
        Vector3 setPosition = monster.transform.position + new Vector3(monsterWidth / 2 , monsterHeight / 2 + offsetY, 0);
        transform.position = setPosition;
    }
}
