using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private MonsterObjectPool monsterObjectPool; 
    public float speed = 5f;      // 이동 속도
    private Monster closestMonster;  // 가장 가까운 몬스터 저장

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

        // 충돌한 오브젝트의 레이어가 "Monster"인지 확인
        if (collision.gameObject.layer == monsterLayer)
        {
            // 충돌한 오브젝트 비활성화
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.Die();
            //collision.gameObject.SetActive(false);  
            
        }
    }

    void FindClosestMonster()
    {
        if (monsterObjectPool.monsters != null) 
        {
            // 모든 몬스터와의 거리를 계산하여 가장 가까운 몬스터 찾기
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
