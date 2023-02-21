using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Sound))]
public class GameRoot : Singleton<GameRoot>
{
    [HideInInspector] public Sound sound;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        sound = Sound.Instance;

        //注册StartUpController
        RegisterController(Consts.E_StartUp, typeof(StartUpController));

        //游戏启动
        SendEvent(Consts.E_StartUp);

        //事件参数
        ScenesArgs e = new ScenesArgs()
        {
            scenesName = Consts.MainMenuScene
        };
        
        //发送事件
        SendEvent(Consts.E_EnterScenes, e);
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