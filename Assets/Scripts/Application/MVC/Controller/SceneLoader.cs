using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public void LoadLevel(int level)
    {
        //发送退出场景事件
        ScenesArgs scenesArgs = new ScenesArgs()
        {
            //获取当前场景索引
            scenesIndex = SceneManager.GetActiveScene().buildIndex
        };

        GameRoot.Instance.SendEvent(Consts.E_ExitScenes, scenesArgs);

        //发送加载新的场景事件
        StartCoroutine(StartLoadNewScenes(level));
    }

    //进入新场景
    IEnumerator StartLoadNewScenes(int level)
    {
        Debug.Log("进入新场景:" + level);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);
        while (!asyncOperation.isDone)
        {
            yield return 0;
        }

        //事件参数
        ScenesArgs scenesArgs = new ScenesArgs() {scenesIndex = level};

        //发布事件
        GameRoot.Instance.SendEvent(Consts.E_EnterScenes, scenesArgs);
    }
}