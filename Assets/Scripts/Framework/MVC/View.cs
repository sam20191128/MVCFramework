using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    //名字标识
    public abstract string Name { get; }

    //事件注意列表
    [HideInInspector] public List<string> AttentionList = new List<string>();

    //注册注意事件
    public virtual void RegisterAttentionEvent()
    {
    }

    //处理事件
    public abstract void HandleEvent(string name, object data);

    //发送事件
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    //获取数据模型
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>();
    }
}