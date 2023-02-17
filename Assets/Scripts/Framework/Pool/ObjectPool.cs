using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    //资源目录
    public string ResourceDir = "";

    private Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();

    //取出
    public GameObject Spawn(string name, Transform trans)
    {
        SubPool pool = null;
        if (!m_pools.ContainsKey(name))
        {
            RegisterNew(name, trans);
        }

        pool = m_pools[name];
        return pool.Spawn();
    }

    //回收
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;
        foreach (var p in m_pools.Values)
        {
            if (p.Contain(go))
            {
                pool = p;
                break;
            }
        }

        pool.Unspawn(go);
    }

    //回收所有
    public void UnspawnAll()
    {
        foreach (var p in m_pools.Values)
        {
            p.UnspawnAll();
        }
    }

    //清除所有
    public void Clear()
    {
        m_pools.Clear();
    }

    //新建池子
    void RegisterNew(string names, Transform trans)
    {
        //资源目录
        string path = ResourceDir + "/" + names;
        //生成预制体
        GameObject go = Resources.Load<GameObject>(path);
        //新建池子
        SubPool pool = new SubPool(trans, go);
        m_pools.Add(pool.Name, pool);
    }
}