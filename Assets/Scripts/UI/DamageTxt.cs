using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class DamageTxt : MonoBehaviour
{
    TextMeshProUGUI damageText;

    public IObjectPool<DamageTxt> objectPool;

    public IObjectPool<DamageTxt> ObjectPool { set => objectPool = value; }

    public float moveSpeed = 1f; // �ؽ�Ʈ�� ���� �̵��ϴ� �ӵ�
    public float fadeDuration = 3f; // �ؽ�Ʈ�� ������ ���������� �� �ɸ��� �ð�
    public float lifetime = 2f; // �ؽ�Ʈ�� ������������ �� �ð�

    private Player player;

    private void Awake()
    {
        damageText = GetComponent<TextMeshProUGUI>();
        player = FindFirstObjectByType<Player>();
    }

    public void Show(Transform transform, float damage)
    {
        //transform.position = transform.position + Vector3.up * 3f;
        damageText.text = damage.ToString();

        damageText.transform.position = transform.position;

        StartCoroutine(DisplayDamageText());
    }

    private IEnumerator DisplayDamageText()
    {
        float elapsedTime = 0f;
        Color textColor = damageText.color;

        // ���� �ֱ� ���� �ִϸ��̼��� �ݺ��մϴ�.
        while (elapsedTime < lifetime)
        {
            // �ؽ�Ʈ�� ���� �̵�
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // ���� ����
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            textColor.a = alpha;
            damageText.color = textColor;

            elapsedTime += Time.deltaTime;
            yield return null; // ���� �����ӱ��� ���
        }

        // �ؽ�Ʈ�� ������ ����� �� ������Ʈ ����
        objectPool.Release(this);
    }
}
