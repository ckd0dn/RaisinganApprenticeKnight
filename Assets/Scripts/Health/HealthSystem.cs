using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private StatHandler statsHandler;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnHealthChanged;
    public event Action<int> OnHealthChangedWithParams;

    public bool isDie = false;

    private void Awake()
    {
        statsHandler = GetComponent<StatHandler>();  
    }


    public void ChangeHealth(float change, bool isCritical = false)
    {
        if (statsHandler.currentHp <= 0) return;

        statsHandler.currentHp += change;

        statsHandler.currentHp = Mathf.Clamp(statsHandler.currentHp, 0, statsHandler.maxHp);

        OnHealthChanged?.Invoke();
        OnHealthChangedWithParams?.Invoke((int)statsHandler.currentHp);

        showDamage(change, isCritical);


        if (statsHandler.currentHp <= 0f)
        {
            OnDeath?.Invoke();
        }

        if (change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }
    }

    public void showDamage(float damage, bool isCritical)
    {
        DamageTxt damageTxt = Managers.Game.DamageTxtObjectPool.objectPool.Get();
        damageTxt.Show(transform, damage, isCritical);
    }
}
