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

    public float moveSpeed = 1f; // 텍스트가 위로 이동하는 속도
    public float fadeDuration = 5f; // 텍스트가 완전히 투명해지는 데 걸리는 시간
    public float lifetime = 5f; // 텍스트가 사라지기까지의 총 시간
    public float offset = 0.0f; // 오브젝트 상단에서 띄울 간격

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

        // 생명 주기 동안 애니메이션을 반복합니다.
        while (elapsedTime < lifetime)
        {
            // 텍스트를 위로 이동
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // 투명도 감소
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            textColor.a = alpha;
            damageText.color = textColor;

            elapsedTime += Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }

        // 텍스트가 완전히 사라진 후 오브젝트 삭제
        objectPool.Release(this);
    }

    private IEnumerator DisplayCriticalDamageText()
    {
        float elapsedTime = 0f;
        Vector3 originalScale = transform.localScale;  // 원래 크기 저장
        Vector3 enlargedScale = originalScale * 1.5f;  // 크기 확대 (1.5배)

        // 생명 주기 동안 애니메이션을 반복합니다.
        while (elapsedTime < lifetime)
        {
            // 텍스트를 위로 이동
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // 크기 변화 (처음엔 크게, 점점 원래 크기로)
            float scaleProgress = Mathf.Lerp(1.5f, 1f, elapsedTime / fadeDuration);  // 1.5배에서 원래 크기로 변화
            transform.localScale = Vector3.Lerp(enlargedScale, originalScale, elapsedTime / fadeDuration);

            // 투명도 감소
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }

        // 텍스트가 완전히 사라진 후 오브젝트 삭제
        objectPool.Release(this);
    }


    void SetTextPosition(Transform obj)
    {

        // 오브젝트의 높이를 계산 (Collider가 있는 경우)
        float objectHeight = GetObjectHeight(obj);

        // 오브젝트의 상단 좌표 계산 (위쪽 + 추가 offset)
        Vector3 worldPosition = obj.position + new Vector3(0, objectHeight / 2 + offset, 0);

        damageText.transform.position = worldPosition;
    }

    float GetObjectHeight(Transform obj)
    {
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null)
        {
            return collider.bounds.size.y; // 오브젝트의 높이 반환
        }

        // 만약 Collider가 없을 경우 기본 높이를 1로 설정 (필요에 따라 조정 가능)
        return 1.0f;
    }
}
