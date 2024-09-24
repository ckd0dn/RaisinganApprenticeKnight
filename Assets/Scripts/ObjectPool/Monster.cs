using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : MonoBehaviour
{
    public IObjectPool<Monster> objectPool;

    public IObjectPool<Monster> ObjectPool { set => objectPool = value; }

    private Player player;

    [SerializeField] private float speed;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();    
    }

    private void OnDisable()
    {
        Invoke("Set", 3f);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    public void Set()
    {
        Monster monster = objectPool.Get();
        SetRandomPosition(monster);
    }

    public void Die()
    {
        objectPool.Release(this);
    }

    public void SetRandomPosition(Monster monster)
    {
        int minX = -9;
        int maxX = 8;
        int minY = -9;
        int maxY = -4;
        int randomOffsetX = Random.Range(minX, maxX);
        int randomOffsetY = Random.Range(minY, maxY);

        monster.transform.position = new Vector3(randomOffsetX, randomOffsetY, transform.position.z);
    }

    void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

}