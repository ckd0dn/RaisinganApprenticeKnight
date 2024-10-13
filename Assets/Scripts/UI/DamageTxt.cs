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
    public float fadeDuration = 5f; // �ؽ�Ʈ�� ������ ���������� �� �ɸ��� �ð�
    public float lifetime = 5f; // �ؽ�Ʈ�� ������������ �� �ð�
    public float offset = 0.0f; // ������Ʈ ��ܿ��� ��� ����

    private Player player;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        damageText = GetComponent<TextMeshProUGUI>();
        player = FindFirstObjectByType<Player>();
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    public void Show(Transform transform, float damage, bool isCritical)
    {
        damageText.text = damage.ToString();

        SetTextPosition(transform);

        if (isCritical)
        {
            StartCoroutine(DisplayCriticalDamageText());
        }
        else
        {
            StartCoroutine(DisplayDamageText());
        }
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

    private IEnumerator DisplayCriticalDamageText()
    {
        float elapsedTime = 0f;
        Vector3 originalScale = transform.localScale;  // ���� ũ�� ����
        Vector3 enlargedScale = originalScale * 1.5f;  // ũ�� Ȯ�� (1.5��)

        // ���� �ֱ� ���� �ִϸ��̼��� �ݺ��մϴ�.
        while (elapsedTime < lifetime)
        {
            // �ؽ�Ʈ�� ���� �̵�
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // ũ�� ��ȭ (ó���� ũ��, ���� ���� ũ���)
            float scaleProgress = Mathf.Lerp(1.5f, 1f, elapsedTime / fadeDuration);  // 1.5�迡�� ���� ũ��� ��ȭ
            transform.localScale = Vector3.Lerp(enlargedScale, originalScale, elapsedTime / fadeDuration);

            // ���� ����
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null; // ���� �����ӱ��� ���
        }

        // �ؽ�Ʈ�� ������ ����� �� ������Ʈ ����
        objectPool.Release(this);
    }


    void SetTextPosition(Transform obj)
    {

        // ������Ʈ�� ���̸� ��� (Collider�� �ִ� ���)
        float objectHeight = GetObjectHeight(obj);

        // ������Ʈ�� ��� ��ǥ ��� (���� + �߰� offset)
        Vector3 worldPosition = obj.position + new Vector3(0, objectHeight / 2 + offset, 0);

        damageText.transform.position = worldPosition;
    }

    float GetObjectHeight(Transform obj)
    {
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null)
        {
            return collider.bounds.size.y; // ������Ʈ�� ���� ��ȯ
        }

        // ���� Collider�� ���� ��� �⺻ ���̸� 1�� ���� (�ʿ信 ���� ���� ����)
        return 1.0f;
    }
}
