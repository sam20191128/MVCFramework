using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ObjectPool : Singleton<ObjectPool>
{
    //池子字典
    private Dictionary<string, SubPool> poolDictionary = new Dictionary<string, SubPool>(); //<名字，子池子>

    //取出
    public GameObject Spawn(string name, Transform transform)
    {
        SubPool subPool = null;

        if (!poolDictionary.ContainsKey(name))
        {
            RegisterNew(name, transform); //注册新池子
        }

        subPool = poolDictionary[name];
        return subPool.Spawn();
    }

    //回收
    public void Unspawn(GameObject gameObject)
    {
        SubPool subPool = null;

        foreach (var p in poolDictionary.Values)
        {
            if (p.Contain(gameObject))
            {
                subPool = p;
                break;
            }
        }

        subPool.Unspawn(gameObject);
    }

    //回收所有
    public void UnSpawnAll()
    {
        foreach (var subPool in poolDictionary.Values)
        {
            subPool.UnspawnAll();
        }
    }

    //清除池子
    public void Clear()
    {
        poolDictionary.Clear();
    }

    //注册新池子
    async Task RegisterNew(string name, Transform transform)
    {
        //生成预制体
        GameObject gameObject = await Addressables.LoadAssetAsync<GameObject>(name).Task;

        //新建池子
        SubPool subPool = new SubPool(transform, gameObject);

        //加入池子字典
        poolDictionary.Add(subPool.Name, subPool);
    }
}