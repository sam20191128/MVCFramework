using UnityEngine;

//可重用的对象,使用对象池的物体继承自此类
public abstract class ReusableObject : MonoBehaviour, IReusable
{
    //抽象类
    
    public abstract void OnSpawn(); //取出

    public abstract void OnUnSpawn(); //回收
}