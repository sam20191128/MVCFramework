using System;
using UnityEngine;

[RequireComponent(typeof(Sound))]
public class GameRoot : Singleton<GameRoot>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        //注册StartUpController
        RegisterController(Consts.E_StartUp, typeof(StartUpController));

        //游戏启动
        SendEvent(Consts.E_StartUp);

        //加载新场景事件的数据
        ScenesArgs scenesArgs = new ScenesArgs()
        {
            //获取当前场景索引
            scenesIndex = 0
        };

        //发送事件
        SendEvent(Consts.E_EnterScenes, scenesArgs);
    }

    //发送事件
    public void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    //注册控制器
    private static void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}