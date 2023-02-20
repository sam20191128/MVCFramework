using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
public class GameRoot : Singleton<GameRoot>
{
    [HideInInspector] public ObjectPool objectPool;
    [HideInInspector] public Sound sound;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        objectPool = ObjectPool.Instance;
        sound = Sound.Instance;

        //注册StartUpController
        RegisterController(Consts.E_StartUp, typeof(StartUpController));

        //游戏启动
        SendEvent(Consts.E_StartUp);

        //事件参数
        ScenesArgs e = new ScenesArgs()
        {
            //获取当前场景索引
            scenesName = Consts.MainMenuScene
        };
        //发布事件
        SendEvent(Consts.E_EnterScenes, e);
    }


    //发送事件
    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    //注册控制器
    void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}