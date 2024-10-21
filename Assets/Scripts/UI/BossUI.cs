using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject bossHpUI;
    public TextMeshProUGUI bossHpText;
    public TextMeshProUGUI bossText;
    public Image bossHpFill;
    public Image bossImg;

    private int bossMaxHp;
    private int bossHp;

    void Start()
    {
        bossHpUI.gameObject.SetActive(false);
        bossText.gameObject.SetActive(false);
    }

    public void AppearBossUI()
    {
        bossHpUI.gameObject.SetActive(true);

        AppearBossText();
    }

    void AppearBossText()
    {
        bossText.gameObject.SetActive(true);

        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < 3; i++)
        {
            sequence.Append(bossText.transform.DOScale(Vector3.one * 1.5f, 0.5f))
                    .Append(bossText.transform.DOScale(Vector3.one, 0.5f));
        }

        sequence.OnComplete(() =>
        {
            bossText.gameObject.SetActive(false);
        });
    }

    public void SetBossData(int currentBossHp, Sprite bossBodySprite)
    {
        bossMaxHp = currentBossHp;
        bossHp = currentBossHp;
        bossHpText.text = currentBossHp.ToString();
        bossHpFill.fillAmount = 1;
        bossImg.sprite = bossBodySprite;
    }

    public void UpdateBossHp(int currentBossHp)
    {
        bossHpText.text = currentBossHp.ToString();
        bossHpFill.fillAmount = (float)currentBossHp / bossMaxHp; 
    }

    public void DisableBossUI()
    {
        bossHpUI.gameObject.SetActive(false);
    }
    
}
