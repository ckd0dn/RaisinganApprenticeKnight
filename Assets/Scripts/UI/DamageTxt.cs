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
    public float fadeDuration = 3f; // 텍스트가 완전히 투명해지는 데 걸리는 시간
    public float lifetime = 2f; // 텍스트가 사라지기까지의 총 시간

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
}
