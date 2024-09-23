using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] monsters;  // ���� �迭
    public float speed = 5f;      // �̵� �ӵ�
    private Transform closestMonster;  // ���� ����� ���� ����

    private void FixedUpdate()
    {
        FindClosestMonster();

        if(closestMonster != null ) 
        {
           MoveToMonster();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int monsterLayer = LayerMask.NameToLayer("Monster");

        // �浹�� ������Ʈ�� ���̾ "Monster"���� Ȯ��
        if (collision.gameObject.layer == monsterLayer)
        {
            // �浹�� ������Ʈ ��Ȱ��ȭ
            collision.gameObject.SetActive(false);  
            
        }
    }

    void FindClosestMonster()
    {
        // ��� ���Ϳ��� �Ÿ��� ����Ͽ� ���� ����� ���� ã��
        closestMonster = monsters
            .Where(monster => monster.gameObject.activeInHierarchy)
            .OrderBy(monster => Vector3.Distance(transform.position, monster.position))
            .FirstOrDefault();
    }

    void MoveToMonster()
    {
        transform.position = Vector2.MoveTowards(transform.position, closestMonster.position, speed * Time.deltaTime);
    }

}
