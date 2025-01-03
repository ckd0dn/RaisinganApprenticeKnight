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
        goldText.text = Managers.Game.currency.GetGold().ToString();
        crystalText.text = Managers.Game.currency.GetCrystal().ToString();
    }
}
