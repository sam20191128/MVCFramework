using System;
using System.Collections.Generic;
using UnityEngine;

public static class MVC
{
    //资源
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>(); //命令映射   事件-类型

    //注册 View
    public static void RegisterView(View view)
    {
        //防止View重复注册
        if (Views.ContainsKey(view.Name))
        {
            Views.Remove(view.Name);
        }

        view.RegisterAttentionEvent();
        Views[view.Name] = view;
    }

    //注册 Model
    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    //注册 Controller
    public static void RegisterController(string eventName, Type controllerType)
    {
        Debug.Log("RegisterController" + eventName);

        CommandMap[eventName] = controllerType;
    }

    //获取 Model
    public static T GetModel<T>() where T : Model
    {
        foreach (var m in Models.Values)
        {
            if (m is T)
            {
                return (T) m;
            }
        }

        return null;
    }

    //获取 View
    public static T GetView<T>() where T : View
    {
        foreach (var v in Views.Values)
        {
            if (v is T)
            {
                return (T) v;
            }
        }

        return null;
    }

    //发送事件
    public static void SendEvent(string eventName, object data = null)
    {
        //Controller执行
        if (CommandMap.ContainsKey(eventName))
        {
            Type t = CommandMap[eventName];
            Controller c = Activator.CreateInstance(t) as Controller; //控制器生成
            c.Execute(data); //执行
        }

        //View处理
        foreach (var v in Views.Values)
        {
            if (v.AttentionList.Contains(eventName))
            {
                v.HandleEvent(eventName, data); //执行
            }
        }

        Debug.Log("SendEvent" + eventName);
    }
}