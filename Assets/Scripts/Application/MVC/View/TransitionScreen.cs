using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TransitionScreen : Singleton<TransitionScreen>
{
    VisualElement transitionImage;
    WaitUntil waitUntilSceneHasLoaded;
    public static event System.Action ShowLoadingScreen;

    void Start()
    {
        transitionImage = GetComponent<UIDocument>().rootVisualElement.Q(name: "TransitionImage");
        waitUntilSceneHasLoaded = new WaitUntil(() => SceneLoader.IsSceneLoaded);

        SceneLoader.LoadingStarted += FadeOut;
        SceneLoader.LoadingCompleted += FadeIn;
    }

    //淡入
    private void FadeIn()
    {
        transitionImage.RemoveFromClassList(Consts.UssFade);
    }

    //淡出
    private void FadeOut()
    {
        transitionImage.AddToClassList(Consts.UssFade);
        transitionImage.RegisterCallback<TransitionEndEvent>(OnFadedOutEnded); //注册UIToolkit过渡结束后Event回调
    }

    //过渡结束后Event回调
    private void OnFadedOutEnded(TransitionEndEvent evt)
    {
        transitionImage.UnregisterCallback<TransitionEndEvent>(OnFadedOutEnded); //移除注册

        if (SceneLoader.ShowLoadingScreen)
        {
            ShowLoadingScreen?.Invoke();
        }
        else
        {
            StartCoroutine(ActivateLoadedSceneCoroutine());
        }
    }

    //激活已加载场景的携程
    IEnumerator ActivateLoadedSceneCoroutine()
    {
        yield return waitUntilSceneHasLoaded;
        
        SceneLoader.ActivateLoadedScene();
    }
}