using System.Collections.Generic;
using UnityEngine;

//子池子
public class SubPool
{
    //集合
    private List<GameObject> m_objecs = new List<GameObject>();

    //预设
    private GameObject m_prefab;

    //名字
    public string Name
    {
        get { return m_prefab.name; }
    }

    //父物体的位置
    private Transform m_parent;

    public SubPool(Transform parent, GameObject go)
    {
        m_prefab = go;
        m_parent = parent;
    }

    //取出物体
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (var obj in m_objecs)
        {
            if (!obj.activeSelf)
            {
                go = obj;
            }
        }

        if (go == null)
        {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            go.transform.parent = m_parent;
            m_objecs.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver); //调用物体上OnSpawn方法

        return go;
    }

    //回收物体
    public void Unspawn(GameObject go)
    {
        if (Contain(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver); //调用物体上OnUnSpawn方法
            go.SetActive(false);
        }
    }

    //回收所有物体
    public void UnspawnAll()
    {
        foreach (var obj in m_objecs)
        {
            if (obj.activeSelf)
            {
                Unspawn(obj);
            }
        }
    }

    //判断是否属于List里边
    public bool Contain(GameObject go)
    {
        return m_objecs.Contains(go);
    }
}