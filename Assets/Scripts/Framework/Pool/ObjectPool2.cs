using System.Collections.Generic;
using UnityEngine;

//AI生成代码
public class ObjectPool2 : MonoBehaviour
{
    //这里是Unity中使用对象池的一种简单高效实现方式

    public GameObject pooledObject;
    public int poolSize;

    private List<GameObject> objects;

    void Start()
    {
        objects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject) Instantiate(pooledObject, transform);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }

        GameObject obj = (GameObject) Instantiate(pooledObject, transform);
        obj.SetActive(false);
        objects.Add(obj);
        return obj;
    }
}

//这个实现方式的核心是使用一个List用于保存生成的对象，并且利用SetActive()方法来控制对象的可见性。
//当需要获取对象时，遍历List中的对象并返回一个处于不活跃状态的对象，
//如果不存在，则通过Instantiate()方法创建一个新的对象并添加到List中。
//这种方式可以大大减少对象的创建和销毁次数，从而提高游戏性能。
//使用这个对象池代码，您只需要将其绑定到一个空的GameObject上，并设置对象池的初始大小和所使用的GameObject即可。