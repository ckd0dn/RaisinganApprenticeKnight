using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private MonsterObjectPool monsterObjectPool; 
    public float speed = 5f;      // �̵� �ӵ�
    private Monster closestMonster;  // ���� ����� ���� ����

    private void Awake()
    {
        monsterObjectPool = FindFirstObjectByType<MonsterObjectPool>();
    }

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
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.Die();
            //collision.gameObject.SetActive(false);  
            
        }
    }

    void FindClosestMonster()
    {
        if (monsterObjectPool.monsters != null) 
        {
            // ��� ���Ϳ��� �Ÿ��� ����Ͽ� ���� ����� ���� ã��
            closestMonster = monsterObjectPool.monsters
                .Where(monster => monster.gameObject.activeInHierarchy)
                .OrderBy(monster => Vector3.Distance(transform.position, monster.transform.position))
                .FirstOrDefault();
        }
       
    }

    void MoveToMonster()
    {
        transform.position = Vector2.MoveTowards(transform.position, closestMonster.transform.position, speed * Time.deltaTime);
    }

}
