using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    //资源目录
    public string ResourceDir = "";

    //池子字典
    private Dictionary<string, SubPool> m_PoolDictionary = new Dictionary<string, SubPool>(); //<名字，子池子>

    //取出
    public GameObject Spawn(string name, Transform transform)
    {
        SubPool subPool = null;

        if (!m_PoolDictionary.ContainsKey(name))
        {
            RegisterNew(name, transform); //注册新池子
        }

        subPool = m_PoolDictionary[name];
        return subPool.Spawn();
    }

    //回收
    public void UnSpawn(GameObject gameObject)
    {
        SubPool subPool = null;

        foreach (var pool in m_PoolDictionary.Values)
        {
            if (pool.Contain(gameObject))
            {
                subPool = pool;
                break;
            }
        }

        subPool.UnSpawn(gameObject);
    }

    //回收所有
    public void UnSpawnAll()
    {
        foreach (var subPool in m_PoolDictionary.Values)
        {
            subPool.UnSpawnAll();
        }
    }

    //清除池子
    public void Clear()
    {
        m_PoolDictionary.Clear();
    }

    //注册新池子
    private void RegisterNew(string names, Transform transform)
    {
        //资源目录
        string path = ResourceDir + "/" + names;

        //生成预制体
        GameObject gameObject = Resources.Load<GameObject>(path);

        //新建池子
        SubPool subPool = new SubPool(transform, gameObject);

        //加入池子字典
        m_PoolDictionary.Add(subPool.Name, subPool);
    }
}