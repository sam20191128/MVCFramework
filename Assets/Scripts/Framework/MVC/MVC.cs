using System;
using System.Collections.Generic;
using UnityEngine;

public static class MVC
{
    //静态字典
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>(); //命令映射   事件-类型

    public static void RegisterView(View view) //注册View
    {
        //防止View重复注册
        if (Views.ContainsKey(view.Name)) //如果已包含View
        {
            Views.Remove(view.Name); //移除View
        }

        view.RegisterAttentionEvent(); //注册关注事件
        Views[view.Name] = view;
    }

    public static void RegisterModel(Model model) //注册数据Model
    {
        Models[model.Name] = model;
    }

    public static void RegisterController(string eventName, Type controllerType) //注册Controller
    {
        Debug.Log("RegisterController: " + eventName);

        CommandMap[eventName] = controllerType;
    }

    public static T GetModel<T>() where T : Model //获取数据Model
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

    public static T GetView<T>() where T : View //获取View
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

    public static void SendEvent(string eventName, object data = null) //发送事件
    {
        //Controller执行
        if (CommandMap.ContainsKey(eventName)) //如果CommandMap包含eventName
        {
            Type type = CommandMap[eventName]; //Type=eventName
            Controller controller = Activator.CreateInstance(type) as Controller; //Controller生成，CreateInstance---寻找匹配的构造方法来创建对象
            controller.Execute(data); //Controller执行
        }

        //View处理
        foreach (var v in Views.Values)
        {
            if (v.AttentionList.Contains(eventName)) //如果View关注事件里包含eventName
            {
                v.HandleEvent(eventName, data); //View执行
            }
        }

        Debug.Log("SendEvent: " + eventName);
    }
}