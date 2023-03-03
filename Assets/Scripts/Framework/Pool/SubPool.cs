using System.Collections.Generic;
using UnityEngine;

public class SubPool
{
    //GameObject列表
    private List<GameObject> m_GameObjects = new List<GameObject>();

    //Prefab
    private GameObject m_goPrefab;

    public string Name => m_goPrefab.name;

    //父物体的位置
    private Transform m_ParentTransform;

    //子池子
    public SubPool(Transform mParent, GameObject mGO)
    {
        m_goPrefab = mGO;
        m_ParentTransform = mParent;
    }

    //取出物体
    public GameObject Spawn()
    {
        GameObject go = null;

        foreach (var obj in m_GameObjects)
        {
            //列表里包含
            if (!obj.activeSelf) //这个游戏对象的本地活动状态=false
            {
                go = obj;
            }
        }

        //列表里不包含
        if (go == null)
        {
            go = GameObject.Instantiate(m_goPrefab);
            go.transform.parent = m_ParentTransform; //设置父级
            m_GameObjects.Add(go); //加入列表
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver); //调用物体上OnSpawn方法

        return go;
    }

    //回收物体
    public void UnSpawn(GameObject go)
    {
        if (Contain(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver); //调用物体上OnUnSpawn方法
            go.SetActive(false);
        }
    }

    //回收所有物体
    public void UnSpawnAll()
    {
        foreach (var obj in m_GameObjects)
        {
            if (obj.activeSelf) //这个游戏对象的本地活动状态=true
            {
                UnSpawn(obj);
            }
        }
    }

    //判断是否属于List里边
    public bool Contain(GameObject go)
    {
        return m_GameObjects.Contains(go);
    }
}