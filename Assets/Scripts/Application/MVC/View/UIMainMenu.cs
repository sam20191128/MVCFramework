using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : View
{
    private Button newGameBtn;
    private Button continueBtn;
    private Button quitBtn;

    public override string Name => Consts.V_MainMenu;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();

        newGameBtn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        continueBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        quitBtn = transform.GetChild(0).GetChild(2).GetComponent<Button>();

        newGameBtn.onClick.AddListener(NewGame);
        continueBtn.onClick.AddListener(ContinueGame);
        quitBtn.onClick.AddListener(QuitGame);
    }


    private static void NewGame()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");

        SceneLoader.LoadAddressableScene(Consts.Game1Scene);
        SceneLoader.ExitSceneEvent();
    }

    private static void ContinueGame()
    {
        SceneLoader.ExitSceneEvent();

        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");

        // //转换场景,读取进度
        // if (SaveManager.Instance.SceneName != "")
        // {
        //     SceneController.Instance.TransitionToLoadGame();
        // }
        Debug.Log("继续游戏");
    }

    private static void QuitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
}