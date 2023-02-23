using System.Collections.Generic;
using UnityEngine;

//抽象类
public abstract class View : MonoBehaviour
{
    public abstract string Name { get; } //名字标识

    [HideInInspector] public List<string> AttentionList = new List<string>(); //事件关注列表

    public virtual void RegisterAttentionEvent() //注册关注事件
    {
    }

    public abstract void HandleEvent(string name, object data); //接受事件后，处理事件

    protected void SendEvent(string eventName, object data = null) //发送事件
    {
        MVC.SendEvent(eventName, data);
    }

    protected T GetModel<T>() where T : Model //获取数据Model
    {
        return MVC.GetModel<T>();
    }
}