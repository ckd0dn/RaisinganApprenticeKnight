using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


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





}
