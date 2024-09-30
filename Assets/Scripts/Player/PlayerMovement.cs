using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


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





}
