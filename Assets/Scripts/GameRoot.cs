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

        //注册 StartUpController
        RegisterController(Consts.E_StartUp, typeof(StartUpController));

        //游戏启动
        SendEvent(Consts.E_StartUp);

        //跳转场景
        GameRoot.Instance.LoadLevel(1);
    }

    public void LoadLevel(int level)
    {
        //发送退出场景事件
        ScenesArgs e = new ScenesArgs()
        {
            //获取当前场景索引
            scenesIndex = SceneManager.GetActiveScene().buildIndex
        };

        SendEvent(Consts.E_ExitScenes, e);

        //发送加载新的场景事件
        StartCoroutine(StartLoadNewScenes(level));
    }

    //进入新场景
    IEnumerator StartLoadNewScenes(int level)
    {
        Debug.Log("进入新场景:" + level);
        AsyncOperation op = SceneManager.LoadSceneAsync(level);
        while (!op.isDone)
        {
            yield return 0;
        }

        //事件参数
        ScenesArgs e = new ScenesArgs() {scenesIndex = level};

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