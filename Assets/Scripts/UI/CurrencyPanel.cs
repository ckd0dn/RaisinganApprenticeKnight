using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyPanel : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI crystalText;

    public void UpdateCrurrencyUI()
    {
        goldText.text = GameManager.Instance.currency.GetGold().ToString();
        crystalText.text = GameManager.Instance.currency.GetCrystal().ToString();
    }
}
