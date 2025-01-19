using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public Player Player { get; private set; }
    public HashSet<Monster> Monsters { get; private set; }
    public HashSet<BossMonster> BossMonsters { get; private set; }

    public T Spawn<T>(string key) where T : BaseController
    {
        System.Type type = typeof(T);

        if(type == typeof(Player))
        {
            GameObject go = Managers.Resource.Instantiate(key);
            Player p = go.GetComponent<Player>();

            return p as T;
        }
        else if(type == typeof(Monster))
        {
            GameObject go = Managers.Resource.Instantiate(key);
            Monster m = go.GetComponent<Monster>();

            Monsters.Add(m);
            return m as T;
        }
        else if (type == typeof(BossMonster))
        {
            GameObject go = Managers.Resource.Instantiate(key);
            BossMonster bm = go.GetComponent<BossMonster>();

            BossMonsters.Add(bm);
            return bm as T;
        }

        return null;
    }

    public void Despawn<T>(T obj) where T : BaseController
    {
        System.Type type = typeof(T);

        if(type == typeof(Player))
        {

        }
        else if(type == typeof(Monster))
        {
            Monsters.Remove(obj as Monster);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if (type == typeof(BossMonster))
        {
            BossMonsters.Remove(obj as BossMonster);
            Managers.Resource.Destroy(obj.gameObject);
        }
    }
}
