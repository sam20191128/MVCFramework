using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    static SceneInstance loadedSceneInstance;

    public static event System.Action LoadingStarted;
    public static event System.Action<float> IsLoading;
    public static event System.Action LoadingSucceeded;
    public static event System.Action LoadingCompleted;
    public static bool ShowLoadingScreen { get; private set; }
    public static bool IsSceneLoaded { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    //异步加载场景(场景名字，是否有加载画面，是否Add加载，是否加载完马上激活)
    public static void LoadAddressableScene(object sceneKey, bool showLoadingScreen = false, bool loadSceneAdditively = false, bool activateOnLoad = false)
    {
        Instance.StartCoroutine(LoadAddressableSceneCoroutine(sceneKey, showLoadingScreen, loadSceneAdditively, activateOnLoad));
    }

    //异步加载场景携程
    // ReSharper disable Unity.PerformanceAnalysis
    static IEnumerator LoadAddressableSceneCoroutine(object sceneKey, bool showLoadingScreen, bool loadSceneAdditively, bool activateOnLoad)
    {
        LoadSceneMode loadSceneMode = loadSceneAdditively ? LoadSceneMode.Additive : LoadSceneMode.Single;
        var asyncOperationHandle = Addressables.LoadSceneAsync(sceneKey, loadSceneMode, activateOnLoad);

        //开始加载
        LoadingStarted?.Invoke();
        ShowLoadingScreen = showLoadingScreen;

        //加载未成功时循环，进度百分比
        while (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
        {
            IsLoading?.Invoke(asyncOperationHandle.PercentComplete);

            yield return null;
        }

        //如果是加载完马上激活，触发这里
        if (activateOnLoad)
        {
            LoadingCompleted?.Invoke();

            ExitSceneEvent(); //发送退出场景事件
            EnterSceneEvent(sceneKey.ToString()); //发送加载新的场景事件

            yield break;
        }

        //如果是加载完不马上激活，触发这里
        LoadingSucceeded?.Invoke();
        IsSceneLoaded = true;
        loadedSceneInstance = asyncOperationHandle.Result; //赋值已加载的实例到loadedSceneInstance，等待激活
    }

    //手动激活已加载的场景
    public static void ActivateLoadedScene()
    {
        loadedSceneInstance.ActivateAsync().completed += _ =>
        {
            ExitSceneEvent(); //发送退出场景事件
            EnterSceneEvent(loadedSceneInstance.Scene.name); //发送加载新的场景事件

            IsSceneLoaded = false;
            loadedSceneInstance = default;
            LoadingCompleted?.Invoke();
        };
    }

    //发送加载新的场景事件
    private static void EnterSceneEvent(string SceneName)
    {
        //事件参数
        ScenesArgs e = new ScenesArgs() {scenesName = SceneName};
        //发布事件
        SendEvent(Consts.E_EnterScenes, e);
    }

    //发送退出场景事件
    private static void ExitSceneEvent()
    {
        //事件参数
        ScenesArgs e = new ScenesArgs()
        {
            //获取当前场景索引
            scenesName = SceneManager.GetActiveScene().name
        };

        SendEvent(Consts.E_ExitScenes, e);
    }

    //发送事件
    private static void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }
}